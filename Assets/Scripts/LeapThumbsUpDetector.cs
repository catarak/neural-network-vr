using UnityEngine;
using System.Collections;

namespace Leap.Unity.ThumbsUpUtility {

	public class LeapThumbsUpDetector : MonoBehaviour {
		[SerializeField]
		protected IHandModel _handModel;

		[SerializeField]
		protected float _activateGrabStrength = 0.9f;

		[SerializeField]
		protected float _activateThumbDirection = 0.8f;

		protected bool _isInThumbsUp = false;
		protected bool _didChange = false;

		protected int _lastUpdateFrame = -1;

		protected float _lastThumbsUpTime = 0.0f;
		protected float _lastUnThumbsUpTime = 0.0f;

		void Awake() {
			if (GetComponent<IHandModel>() != null) {
				Debug.LogWarning("LeapThumbsUpDetector should not be attached to the IHandModel's transform. It should be attached to its own transform.");
			}
			if (_handModel == null) {
				Debug.LogWarning("The HandModel field of LeapThumbsUpDetector was unassigned and the detector has been disabled.");
				enabled = false;
			}
		}
		
		void Update () {
			ensureThumbsUpInfoUpToDate ();
		}

		/// <summary>
		/// Returns whether or not the dectector is currently detecting a thumbs up.
		/// </summary>
		public bool IsInThumbsUp {
			get {
				ensureThumbsUpInfoUpToDate();
				return _isInThumbsUp;
			}
		}

		/// <summary>
		/// Returns whether or not the value of IsInThumbsUp is different than the value reported during
		/// the previous frame.
		/// </summary>
		public bool DidChangeFromLastFrame {
			get {
				ensureThumbsUpInfoUpToDate();
				return _didChange;
			}
		}

		/// <summary>
		/// Returns whether or not the value of IsInThumbsUp changed to true between this frame and the previous.
		/// </summary>
		public bool DidStartThumbsUp {
			get {
				ensureThumbsUpInfoUpToDate();
				return DidChangeFromLastFrame && IsInThumbsUp;
			}
		}

		/// <summary>
		/// Returns whether or not the value of IsInThumbsUp changed to false between this frame and the previous.
		/// </summary>
		public bool DidEndThumbsUp {
			get {
				ensureThumbsUpInfoUpToDate();
				return DidChangeFromLastFrame && !IsInThumbsUp;
			}
		}

		/// <summary>
		/// Returns the value of Time.time during the most recent thumbs up event.
		/// </summary>
		public float LastThumbsUpTime {
			get {
				ensureThumbsUpInfoUpToDate();
				return _lastThumbsUpTime;
			}
		}

		/// <summary>
		/// Returns the value of Time.time during the most recent un-thumbs up event.
		/// </summary>
		public float LastUnThumbsUpTime {
			get {
				ensureThumbsUpInfoUpToDate();
				return _lastUnThumbsUpTime;
			}
		}

		private void ensureThumbsUpInfoUpToDate() {
			if (Time.frameCount == _lastUpdateFrame) {
				return;
			}
			_lastUpdateFrame = Time.frameCount;

			_didChange = false;

			Hand hand = _handModel.GetLeapHand();

			if (hand == null || !_handModel.IsTracked) {
				changeThumbsUpState(false);
				return;
			}

			if (_isInThumbsUp) {
				int numExtended = 0;

				if (hand.Fingers [(int)Finger.FingerType.TYPE_INDEX].IsExtended) {
					numExtended += 1;
				}
				if (hand.Fingers [(int)Finger.FingerType.TYPE_MIDDLE].IsExtended) {
					numExtended += 1;
				}
				if (hand.Fingers [(int)Finger.FingerType.TYPE_RING].IsExtended) {
					numExtended += 1;
				}
				if (hand.Fingers [(int)Finger.FingerType.TYPE_PINKY].IsExtended) {
					numExtended += 1;
				}

				if (!hand.Fingers [(int)Finger.FingerType.TYPE_THUMB].IsExtended
				    || numExtended > 0
				    || hand.GrabStrength < _activateGrabStrength
				    || hand.Fingers [(int)Finger.FingerType.TYPE_THUMB].Direction.ToVector3 ().y < _activateThumbDirection) {
					changeThumbsUpState (false);
					return;
				}
			} else {
				if (hand.Fingers [(int)Finger.FingerType.TYPE_THUMB].IsExtended
					&& !hand.Fingers [(int)Finger.FingerType.TYPE_INDEX].IsExtended
					&& !hand.Fingers [(int)Finger.FingerType.TYPE_MIDDLE].IsExtended
					&& !hand.Fingers [(int)Finger.FingerType.TYPE_RING].IsExtended
					&& !hand.Fingers [(int)Finger.FingerType.TYPE_PINKY].IsExtended) {
					if (hand.GrabStrength > _activateGrabStrength) {
						if (hand.Fingers [(int)Finger.FingerType.TYPE_THUMB].Direction.ToVector3 ().y > _activateThumbDirection) {
							changeThumbsUpState (true);
							return;
						}
					}

				}
			}
		}

		void changeThumbsUpState(bool shouldBeInThumbsUp) {
			if (_isInThumbsUp != shouldBeInThumbsUp) {
				_isInThumbsUp = shouldBeInThumbsUp;

				if (_isInThumbsUp) {
					_lastThumbsUpTime = Time.time;
				} else {
					_lastUnThumbsUpTime = Time.time;
				}

				_didChange = true;
			}
		}
	}
}
