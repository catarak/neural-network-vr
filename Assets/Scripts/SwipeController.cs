using UnityEngine;
using System.Collections;

namespace Leap.Unity.SwipeUtility {
	public class SwipeController : MonoBehaviour {
		[SerializeField]
		private LeapSwipeDetector _swipeDetectorA;

		[SerializeField]
		private LeapSwipeDetector _swipeDetectorB;

		[SerializeField]
		private GameController gameController;

		void Awake() {
			if (_swipeDetectorA == null || _swipeDetectorB == null) {
				Debug.LogWarning("Both Swipe Detectors of the SwipeController component must be assigned. This component has been disabled.");
				enabled = false;
			}
		}

		void Update () {
			bool didUpdate = false;
			didUpdate |= _swipeDetectorA.DidChangeFromLastFrame;
			didUpdate |= _swipeDetectorB.DidChangeFromLastFrame;

			if (didUpdate) {
				if (_swipeDetectorA.IsSwiping && _swipeDetectorB.IsSwiping) {
					//do nothing
				} else if (_swipeDetectorB.IsSwiping) { //check right hand first since most people are right handed
					if (_swipeDetectorB.GetSwipeDirection == LeapSwipeDetector.SwipeDirection.Right) {
						//go to next layer
						gameController.nextState();
					} else {
						//go to previous layer
						gameController.previousState();
					}
				}
			}
		}
	}
}
