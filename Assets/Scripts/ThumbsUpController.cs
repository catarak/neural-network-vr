using UnityEngine;
using System.Collections;

namespace Leap.Unity.ThumbsUpUtility {
	public class ThumbsUpController : MonoBehaviour {
		[SerializeField]
		private LeapThumbsUpDetector _thumbsUpDetectorA;

		[SerializeField]
		private LeapThumbsUpDetector _thumbsUpDetectorB;

		[SerializeField]
		private GameController gameController;

		private bool _canThumbsUpAgainA = false;
		private bool _canThumbsUpAgainB = false;

		void Awake() {
			if (_thumbsUpDetectorA == null || _thumbsUpDetectorB == null) {
				Debug.LogWarning("Both Thumbs Up Detectors of the ThumbsUpController component must be assigned. This component has been disabled.");
				enabled = false;
			}
		}

		void Update () {
			bool didUpdate = false;
			didUpdate |= _thumbsUpDetectorA.DidChangeFromLastFrame;
			didUpdate |= _thumbsUpDetectorB.DidChangeFromLastFrame;

			if (Time.time - _thumbsUpDetectorB.LastThumbsUpTime > 5.0f) {
				_canThumbsUpAgainB = true;
			}
			if (Time.time - _thumbsUpDetectorA.LastThumbsUpTime > 5.0f) {
				_canThumbsUpAgainA = true;
			}
				
			if (didUpdate) {
				if (_thumbsUpDetectorA.IsInThumbsUp && _thumbsUpDetectorB.IsInThumbsUp) {
					//do nothing
				} else if (_thumbsUpDetectorB.IsInThumbsUp && _canThumbsUpAgainA && _canThumbsUpAgainB) { //check right hand first since most people are right handed
					gameController.nextState ();
					_canThumbsUpAgainB = false;
				} else if (_thumbsUpDetectorA.IsInThumbsUp && _canThumbsUpAgainA && _canThumbsUpAgainB) {
					gameController.nextState ();
					_canThumbsUpAgainA = false;
				}
			}
		}
	}
}
