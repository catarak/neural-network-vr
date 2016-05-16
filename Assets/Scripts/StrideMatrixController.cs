using UnityEngine;
using System.Collections;
using Leap.Unity;

public class StrideMatrixController : MonoBehaviour {
	[SerializeField]
	public float _strideStep = 0.02f;
//	[SerializeField]
//	private float _strideLimit = 0.27f;
	[SerializeField]
	public float _strideRange = 0.54f;

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;

	private bool _isDragging = false;

	public bool canDrag = true;

	public GameObject[] attachedMatrices;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (canDrag && IsHand (other)) {
			_isDragging = true;
//			GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<ConvolutionAnimationController> ().stopAnimating();
//			GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<ConvolutionAnimationController> ().resetAnimation ();
		}
	}

	void OnTriggerStay(Collider other) {
		if (canDrag && IsHand (other)) {
			//get position of hand
			//move stride to quanitized position, closest to hand position
			Vector3 handPosition = other.gameObject.transform.position;
			Vector3 positionDifference = handPosition - transform.position;
			float diffX = positionDifference.z;
			float diffY = positionDifference.y;
			int spacesToMoveX = (int)(diffX / _strideStep);
			int spacesToMoveY = (int)(diffY / _strideStep);

			float newX = transform.localPosition.x + spacesToMoveX * _strideStep;
			float newY = transform.localPosition.y + spacesToMoveY * _strideStep;

			if (newX > maxX) {
				newX = maxX;
			}
			if (newX < minX) {
				newX = minX;
			}
			if (newY > maxY) {
				newY = maxY;
			}
			if (newY < minY) {
				newY = minY;
			}

			GameObject[] smallStrideMatrices = GameObject.FindGameObjectsWithTag ("smallStrideMatrix");
			float newDiffX = newX - transform.localPosition.x;
			float newDiffY = newY - transform.localPosition.y;

			int newXSteps = Mathf.RoundToInt(newDiffX / _strideStep);
			int newYSteps = Mathf.RoundToInt(newDiffY / _strideStep);

			for (int i = 0; i < attachedMatrices.Length; i++) {
				attachedMatrices [i].GetComponent<StrideMatrixController> ().moveBySteps (newXSteps, newYSteps);
			}
				
			transform.localPosition = new Vector3 (newX, newY, transform.localPosition.z);
		}
	}

	void OnTriggerExit(Collider other) {
		if (canDrag && IsHand (other)) {
//			GameObject.FindGameObjectWithTag ("GameController").gameObject.GetComponent<ConvolutionAnimationController> ().startAnimating();
		}
	}

	private bool IsHand(Collider other) {
		if (other.transform.parent && other.transform.parent.parent
			&& other.transform.parent.parent.GetComponent<RigidHand> ()) {
			return true;
		} else {
			return false;
		}
	}

	//this assumes upper left corner
	public void setInitialPosition(Vector3 initialPosition) {
		minX = initialPosition.x;
		maxY = initialPosition.y;

		maxX = minX + _strideRange;
		minY = maxY - _strideRange;
	}

	public void moveBySteps(int x, int y) {
		transform.localPosition = new Vector3 (transform.localPosition.x + x*_strideStep, transform.localPosition.y + y*_strideStep, transform.localPosition.z);
	}
}
