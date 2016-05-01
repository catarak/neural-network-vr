using UnityEngine;
using System.Collections;
using Leap;

public class GestureController : MonoBehaviour {
	Controller controller;

//	void Start () {
//		controller = new Controller ();
//		controller.EnableGesture (Gesture.GestureType.TYPE_KEY_TAP);
////		controller.Config.SetFloat ("Gesture.ScreenTap.MinForwardVelocity", 30.0f);
////		controller.Config.SetFloat ("Gesture.ScreenTap.HistorySeconds", .5f);
////		controller.Config.SetFloat ("Gesture.ScreenTap.MinDistance", 1.0f);
////		controller.Config.Save ();
//	}
//
//	void Update () {
//		Frame frame = controller.Frame ();
//		GestureList gestures = frame.Gestures ();
//		for (int i = 0; i < gestures.Count; i++) {
//			Gesture gesture = gestures [i];
//			if (gesture.Type == Gesture.GestureType.TYPE_KEY_TAP) {
//				KeyTapGesture tap = new KeyTapGesture (gesture);
//				Pointable tappingPointable = tap.Pointable;
//				Finger finger = new Finger (tappingPointable);
//				Debug.Log (finger.Type);
//			}
//		}	
//	}
}