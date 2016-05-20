using UnityEngine;
using System.Collections;

public class Hidden2AnimationController : MonoBehaviour {
	public GameObject lines2;

	private bool _isAnimating = false;

	public void startAnimating() {
		_isAnimating = true;
		StartCoroutine (animateLines ());
	}

	public void stopAnimating() {
		_isAnimating = false;
		StopAllCoroutines ();
	}

	public IEnumerator animateLines() {
		for (int i = 119; i >= 0; i--) {
			GameObject lines = lines2.transform.GetChild (i).gameObject;
			lines.SetActive (true);
			lines.GetComponent<AudioSource> ().Play ();
			yield return new WaitForSeconds (2);
			lines.SetActive (false);
		}
	}
}
