using UnityEngine;
using System.Collections;

namespace Leap.Unity.SwipeUtility {
	public class LeapSwipeDetector : MonoBehaviour {
		[SerializeField]
		protected IHandModel _handModel;

		[SerializeField]
		protected float _activateSwipePalmNormal = 0.9f;

		[SerializeField]
		protected float _activateSwipePalmVelocity = 1.0f; 

		[SerializeField]
		protected float _minSwipeDistance = 0.15f; 

		protected Vector3 _swipeStartPos = Vector3.zero;

		protected int _lastUpdateFrame = -1;

		protected bool _isSwiping = false;
		protected bool _didChange = false;

		protected float _lastSwipeTime = 0.0f;
		protected float _lastUnSwipeTime = 0.0f;

		public enum SwipeDirection {Left,Right};

		protected SwipeDirection swipeDirection;

		protected virtual void Awake() {
			if (GetComponent<IHandModel>() != null) {
				Debug.LogWarning("LeapSwipeDetector should not be attached to the IHandModel's transform. It should be attached to its own transform.");
			}
			if (_handModel == null) {
				Debug.LogWarning("The HandModel field of LeapSwipeDetector was unassigned and the detector has been disabled.");
				enabled = false;
			}
		}

		void Update () {
			ensureSwipeInfoUpToDate ();
			if (_isSwiping) {
				Debug.Log (swipeDirection);
			}
		}

		/// <summary>
		/// Returns whether or not the dectector is currently detecting a swipe.
		/// </summary>
		public bool IsSwiping {
			get {
				ensureSwipeInfoUpToDate();
				return _isSwiping;
			}
		}

		public SwipeDirection GetSwipeDirection {
			get {
				ensureSwipeInfoUpToDate ();
				return swipeDirection;
			}
		}

		/// <summary>
		/// Returns whether or not the value of IsSwiping is different than the value reported during
		/// the previous frame.
		/// </summary>
		public bool DidChangeFromLastFrame {
			get {
				ensureSwipeInfoUpToDate();
				return _didChange;
			}
		}


		protected virtual void ensureSwipeInfoUpToDate() {
			if (Time.frameCount == _lastUpdateFrame) {
				return;
			}
			_lastUpdateFrame = Time.frameCount;

			_didChange = false;

			Hand hand = _handModel.GetLeapHand();

			if (hand == null || !_handModel.IsTracked) {
				changeSwipeState(false);
				return;
			}

			Transform centerEyeAnchor = _handModel.transform.parent.parent.parent;
			float rotationY = centerEyeAnchor.rotation.eulerAngles.y;
			Vector3 palmNormal = Quaternion.Euler (0, -rotationY, 0) * hand.PalmNormal.ToVector3 ();
			Vector3 palmVelocity = Quaternion.Euler (0, -rotationY, 0) * hand.PalmVelocity.ToVector3 ();

//			if (hand.IsRight && palmNormal.x < -_activateSwipePalmNormal) {
//				Debug.Log ("Palm facing to the left, right hand.");
//				if (palmVelocity.x > _activateSwipePalmVelocity || palmVelocity.x < _activateSwipePalmVelocity) {
//					_swipeStartPos = hand.PalmPosition.ToVector3();
//				}
//				Debug.Log (palmVelocity);
//			} else if (hand.IsLeft && palmNormal.x > _activateSwipePalmNormal) {
//				Debug.Log ("Palm facing to the right, left hand.");
//				Debug.Log (palmVelocity);
//			}

//			Vector3 palmVelocity = Quaternion.Euler (0, -rotationY, 0) * hand.PalmVelocity.ToVector3 ();
//			Debug.Log (palmVelocity.x);

			if (_isSwiping) {
				if (Mathf.Abs(palmVelocity.x) < _activateSwipePalmVelocity) {
					changeSwipeState(false);
					_swipeStartPos = Vector3.zero;
					return;
				}
			} else {
				if (_swipeStartPos != Vector3.zero) {
					if (Vector3.Distance (hand.PalmPosition.ToVector3(), _swipeStartPos) > _minSwipeDistance) {
						changeSwipeState (true);
					}
				}
				else if ((hand.IsRight && palmNormal.x < -_activateSwipePalmNormal) || (hand.IsLeft && palmNormal.x > _activateSwipePalmNormal)) {
					if (Mathf.Abs (palmVelocity.x) > _activateSwipePalmVelocity) {
						_swipeStartPos = hand.PalmPosition.ToVector3();
						if (palmVelocity.x > 0) {
							swipeDirection = SwipeDirection.Right;
						} else {
							swipeDirection = SwipeDirection.Left;
						}
					}
				}
			}
				
//			if (_isPinching) {
//				_pinchPos = transform.position;
//				_pinchRotation = transform.rotation;
//			}
				
		}

		protected virtual void changeSwipeState(bool shouldBeSwiping) {
			if (_isSwiping != shouldBeSwiping) {
				_isSwiping = shouldBeSwiping;

				if (_isSwiping) {
					_lastSwipeTime = Time.time;
				} else {
					_lastUnSwipeTime = Time.time;
				}

				_didChange = true;
			}
		}
	}
}
