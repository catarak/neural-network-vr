using UnityEngine;
using System.Collections;
using Leap.Unity;

public class CubeController : MonoBehaviour {
	public float value = 0.0f;
	public GameObject ValueLabel;

	private GameController gameController;

	public bool isAnimating = false;
	public Vector3 animationStartPosition;
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (transform.parent.CompareTag ("image")) {
			if (IsHand (other)) {
				if (transform.Find ("ValueLabel") == null) {
					GameObject instance = Instantiate (ValueLabel, transform.position, transform.rotation) as GameObject;
					instance.name = "ValueLabel";
					instance.transform.parent = transform;
//				instance.transform.localRotation = Quaternion.Euler (90, 0, 0);
					instance.transform.localPosition = new Vector3 (0f, 0f, -0.52f);
					instance.GetComponent<TextMesh> ().text = value.ToString ("0.00");
				}
			}
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

	public IEnumerator animateUpAndDown() {
		isAnimating = true;
		animationStartPosition = transform.position;
		while (true) {
			Vector3 middlePosition = transform.position;
			Vector3 topPosition = new Vector3 (transform.position.x, transform.position.y + 0.05f, transform.position.z);
			Vector3 bottomPosition = new Vector3 (transform.position.x, transform.position.y - 0.05f, transform.position.z);
			float elapsedTime = 0.0f;
			float time = 0.5f;
			while (elapsedTime < time) {
				transform.position = Vector3.Lerp (middlePosition, topPosition, (elapsedTime / time));
				elapsedTime += Time.deltaTime;
				yield return new WaitForEndOfFrame ();
			}

			elapsedTime = 0.0f;
			time = 1f;
			while (elapsedTime < time) {
				transform.position = Vector3.Lerp (topPosition, bottomPosition, (elapsedTime / time));
				elapsedTime += Time.deltaTime;
				yield return new WaitForEndOfFrame ();
			}

			elapsedTime = 0.0f;
			time = 0.5f;
			while (elapsedTime < time) {
				transform.position = Vector3.Lerp (bottomPosition, middlePosition, (elapsedTime / time));
				elapsedTime += Time.deltaTime;
				yield return new WaitForEndOfFrame ();
			}
		}
	}

	private IEnumerator moveToPosition(Vector3 position, float time) {
		isAnimating = true;
		float elapsedTime = 0.0f;
		Vector3 startingPosition = transform.position;
		while (elapsedTime < time) {
			transform.position = Vector3.Lerp (startingPosition, position, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
		isAnimating = false;
	}

}
