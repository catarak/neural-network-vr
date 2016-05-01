using UnityEngine;
using System.Collections;
using Leap;

public class Drawer : MonoBehaviour {

//  public CanvasAutomation canvas;
//
//  private const float THUMB_TRIGGER_DISTANCE = 0.04f;
//  private const float MIN_CONFIDENCE = 0.2f;
//
//	void Update () {
//	HandModel hand_model = GetComponent<HandController>().rightPhysicsModel;
//    Hand leap_hand = hand_model.GetLeapHand();
//
//    if (leap_hand == null)
//      return;
//	
//	Debug.Log ("leap hand is not null");
//    bool draw_trigger = false;
//    Vector3 thumb_tip = leap_hand.Fingers[0].TipPosition.ToUnityScaled();
//
//    for (int i = 1; i < 5 && !draw_trigger; ++i) {
//      for (int j = 0; j < 4 && !draw_trigger; ++j) {
//        Finger.FingerJoint joint = (Finger.FingerJoint)(j);
//        Vector3 difference = leap_hand.Fingers[i].JointPosition(joint).ToUnityScaled() - thumb_tip;
//
//        if (difference.magnitude < THUMB_TRIGGER_DISTANCE && leap_hand.Confidence > MIN_CONFIDENCE)
//          draw_trigger = true;
//      }
//    }
//	
//
//	if (draw_trigger) {
//		Debug.Log ("drawing!");
//		canvas.AddNextPoint (hand_model.fingers [1].GetJointPosition (FingerModel.NUM_JOINTS - 1));
//	}
//  }
}
