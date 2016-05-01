using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialController : MonoBehaviour {
	private bool _started = false;
	public GameObject cube;
	public GameObject canvas;

	void Start () {

	}

	IEnumerator WaitAndStart() {
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("Main");
	}

	void Update () {
		if (!_started) {
			if (Input.GetKeyDown (KeyCode.S)) {
				_started = true;
				GetComponent<AudioSource> ().Play ();
				StartCoroutine (fadeInOutCube());
			}
		} else {
			if (!GetComponent<AudioSource> ().isPlaying) {
				StartCoroutine (WaitAndStart ());
			}
		}
	}

	IEnumerator fadeInOutCube() {
		yield return new WaitForSeconds (15);
		cube.SetActive (true);
		canvas.SetActive (false);
		yield return new WaitForSeconds (10);
		cube.SetActive (false);
		canvas.SetActive (true);
	}
}
