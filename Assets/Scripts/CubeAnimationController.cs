using UnityEngine;
using System.Collections;

public class CubeAnimationController : MonoBehaviour {
	public bool isAnimating = false;
	public AudioClip c;
	public AudioClip g;
	public AudioClip c2;

	void Start () {
	
	}

	void Update () {
	
	}

	public IEnumerator moveToPosition(Vector3 position, Quaternion rotation, float time) {
		isAnimating = true;
		playSound ();
		float elapsedTime = 0.0f;
		Vector3 startingPosition = transform.position;
		Quaternion startingRotation = transform.rotation;
		while (elapsedTime < time) {
			transform.position = Vector3.Lerp (startingPosition, position, (elapsedTime / time));
			transform.rotation = Quaternion.Lerp (startingRotation, rotation, (elapsedTime / time));
			elapsedTime += Time.deltaTime;
			yield return new WaitForEndOfFrame ();
		}
		isAnimating = false;
	}

	private void playSound() {
		GetComponent<AudioSource> ().Play ();
	}
}
