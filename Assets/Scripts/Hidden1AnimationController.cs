using UnityEngine;
using System.Collections;

public class Hidden1AnimationController : MonoBehaviour {
	public GameObject lines1;
	public GameObject down2Output;

	private bool _isAnimating;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void startAnimating() {
		_isAnimating = true;
		StartCoroutine (animateLines ());
	}

	public void stopAnimating() {
		_isAnimating = false;
		StopAllCoroutines ();
	}

	public IEnumerator animateLines() {
		GameObject strideMatrix = GameObject.FindGameObjectsWithTag ("smallStrideMatrix") [0];
		while (true) {
			for (int i = 0; i < 16; i++) {
				int cubePosition = strideMatrixToCubePosition(strideMatrix);
				for (int j = 0; j < 25; j++) {
					GameObject lines = lines1.transform.GetChild (i).GetChild (j).gameObject;
					if (j == cubePosition) {
						lines.SetActive (true);
						lines.GetComponent<AudioSource> ().Play ();
					} else {
						lines.SetActive (false);
					}
				}
				yield return new WaitForSeconds (2);
				lines1.transform.GetChild (i).GetChild (cubePosition).gameObject.SetActive (false);
			}
		}
	}

	private int strideMatrixToCubePosition(GameObject strideMatrix) {
		int column = Mathf.RoundToInt((strideMatrix.transform.localPosition.x - strideMatrix.GetComponent<StrideMatrixController>().minX) / 0.02f);
		int row = Mathf.RoundToInt((strideMatrix.transform.localPosition.y - strideMatrix.GetComponent<StrideMatrixController>().minY) / 0.02f);
		return row * 5 + column;
	}
}
