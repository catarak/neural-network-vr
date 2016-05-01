using UnityEngine;
using System.Collections;

namespace Leap.Unity.GrabUtility {
	public class LeapGrabDetector : MonoBehaviour {
		[SerializeField]
		protected IHandModel _handModel;

		[SerializeField]
		protected float _activateGrabStrength = 0.9f;

		protected bool _isGrabbing = false;
		protected bool _didChange = false;

		protected int _lastUpdateFrame = -1;

		protected float _lastGrabTime = 0.0f;
		protected float _lastUnGrabTime = 0.0f;

		void Awake() {
			if (GetComponent<IHandModel>() != null) {
				Debug.LogWarning("LeapGrabDetector should not be attached to the IHandModel's transform. It should be attached to its own transform.");
			}
			if (_handModel == null) {
				Debug.LogWarning("The HandModel field of LeapSwipeDetector was unassigned and the detector has been disabled.");
				enabled = false;
			}
		}

		void Update () {
			ensureGrabInfoUpToDate ();
			if (IsGrabbing) {
				Debug.Log (IsGrabbing);
			}
		}

		/// <summary>
		/// Returns whether or not the dectector is currently detecting a swipe.
		/// </summary>
		public bool IsGrabbing {
			get {
				ensureGrabInfoUpToDate();
				return _isGrabbing;
			}
		}

		void ensureGrabInfoUpToDate() {
			if (Time.frameCount == _lastUpdateFrame) {
				return;
			}
			_lastUpdateFrame = Time.frameCount;

			_didChange = false;

			Hand hand = _handModel.GetLeapHand();

			if (hand == null || !_handModel.IsTracked) {
				changeGrabState(false);
				return;
			}
				
			if (_isGrabbing) {
				if (hand.GrabStrength < _activateGrabStrength) {
					changeGrabState (false);
					return;
				}
			}
			else if (hand.GrabStrength > _activateGrabStrength) {
				changeGrabState (true);

			}
		}

		void changeGrabState(bool shouldBeGrabbing) {
			if (_isGrabbing != shouldBeGrabbing) {
				_isGrabbing = shouldBeGrabbing;

				if (_isGrabbing) {
					_lastGrabTime = Time.time;
				} else {
					_lastUnGrabTime = Time.time;
				}

				_didChange = true;
			}
		}
	}
}
