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
		for (int i = 0; i < 120; i++) {
			GameObject lines = lines2.transform.GetChild (i).gameObject;
			lines.SetActive (true);
			yield return new WaitForSeconds (1);
			lines.SetActive (false);
		}
	}
}
