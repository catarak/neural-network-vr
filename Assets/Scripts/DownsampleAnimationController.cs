using UnityEngine;
using System.Collections;

public class DownsampleAnimationController : MonoBehaviour {
	private bool _isAnimating = false;
	public GameObject CubeAnimationObject;
	private GameObject[] inputMatrices = new GameObject[6];
	private GameObject[] outputCubes = new GameObject[6];
	private bool _animatingInputCubes = false;
	private bool _animatingOutputCubes = false;

	public GameObject conv1Output;
	public GameObject down1Output;

	void Update () {
		if (_isAnimating) {
			if (_animatingInputCubes) {
				if (!inputMatrices [5].GetComponent<CubeAnimationController> ().isAnimating) {
					_animatingInputCubes = false;
					destroyInputCubes ();
					createOutputCubes ();
					animateOutputCubes ();
				}
			}
			if (_animatingOutputCubes) {
				if (!outputCubes [5].GetComponent<CubeAnimationController> ().isAnimating) {
					_animatingOutputCubes = false;
					destroyOutputCubes ();
					createInputCubes ();
					animateInputCubes ();
				}
			}
		}
	
	}

	public void startAnimating() {
		_isAnimating = true;
		createInputCubes ();
		animateInputCubes ();
	}

	public void stopAnimating() {
		_isAnimating = false;
	}

	private void createInputCubes() {
		GameObject[] inputStrideMatrices = GameObject.FindGameObjectsWithTag ("downStrideMatrix");
		int[] inputCubePositions = strideMatrixToCubePositions (inputStrideMatrices [0]);

		for (int i = 0; i < 6; i++) {
			GameObject cubeAnimationObject = Instantiate (CubeAnimationObject, inputStrideMatrices [i].transform.position, inputStrideMatrices [i].transform.rotation) as GameObject;
			for (int j = 0; j < inputCubePositions.Length; j++) {
				GameObject cube = conv1Output.transform.GetChild (i).GetChild (inputCubePositions [j]).gameObject;
				GameObject cubeClone = Instantiate (cube, cube.transform.position, cube.transform.rotation) as GameObject;
				cubeClone.transform.parent = cubeAnimationObject.transform;
			}
			inputMatrices [i] = cubeAnimationObject;
		}
	}

	private void animateInputCubes() {
		_animatingInputCubes = true;
		for (int i = 0; i < 6; i++) {
			Vector3 centerCubePosition = conv1Output.transform.GetChild (i).GetChild (392).transform.position;
			Vector3 moveToPosition = new Vector3 (0, centerCubePosition.y, centerCubePosition.z);
			Quaternion moveToRotation = conv1Output.transform.GetChild (i).rotation;
			StartCoroutine(inputMatrices[i].GetComponent<CubeAnimationController> ().moveToPosition (moveToPosition, moveToRotation, 5f));
		}
	}

	private void destroyInputCubes() {
		for (int i = 0; i < 6; i++) {
			Destroy (inputMatrices [i]);
		}
	}

	private void createOutputCubes() {
		for (int i = 0; i < 6; i++) {
			GameObject strideMatrix = GameObject.FindGameObjectsWithTag ("smallStrideMatrix")[i];
			int cubeIndex = strideMatrixToCubePosition (strideMatrix);

			GameObject cube = down1Output.transform.GetChild (i).GetChild (cubeIndex).gameObject;
			Vector3 centerCubePosition = conv1Output.transform.GetChild (i).GetChild (392).transform.position;
			Vector3 startPosition = new Vector3 (0, centerCubePosition.y, centerCubePosition.z);
			Quaternion startRotation = conv1Output.transform.GetChild (i).rotation;

			GameObject cubeClone = Instantiate (cube, startPosition, startRotation) as GameObject;
			GameObject cubeAnimator = Instantiate (CubeAnimationObject, startPosition, startRotation) as GameObject;
			cubeClone.transform.parent = cubeAnimator.transform;
			outputCubes [i] = cubeAnimator;
		}
	}

	private void animateOutputCubes() {
		_animatingOutputCubes = true;
		for (int i = 0; i < 6; i++) {
			GameObject strideMatrix = GameObject.FindGameObjectsWithTag ("smallStrideMatrix")[i];
			int cubeIndex = strideMatrixToCubePosition (strideMatrix);
			GameObject cube = down1Output.transform.GetChild (i).GetChild (cubeIndex).gameObject;

			StartCoroutine(outputCubes[i].GetComponent<CubeAnimationController> ().moveToPosition (cube.transform.position, cube.transform.rotation, 5f));
		}
	}

	private void destroyOutputCubes() {
		for (int i = 0; i < 6; i++) {
			Destroy (outputCubes [i]);
		}
	}

	private int[] strideMatrixToCubePositions(GameObject strideMatrix) {
		int startColumn = Mathf.RoundToInt((strideMatrix.transform.localPosition.x - strideMatrix.GetComponent<StrideMatrixController>().minX) / 0.02f);
		int startRow = Mathf.RoundToInt((strideMatrix.transform.localPosition.y - strideMatrix.GetComponent<StrideMatrixController>().minY) / 0.02f);
		int[] cubePositions = new int[4];
		int index = 0;
		for (int i = 0; i < 2; i++) {
			for (int j = 0; j < 2; j++) {
				cubePositions [index] = (startRow+i)*28 + startColumn + j;
				index++;
			}
		}
		return cubePositions;
	}

	private int strideMatrixToCubePosition(GameObject strideMatrix) {
		int column = Mathf.RoundToInt((strideMatrix.transform.localPosition.x - strideMatrix.GetComponent<StrideMatrixController>().minX) / 0.02f);
		int row = Mathf.RoundToInt((strideMatrix.transform.localPosition.y - strideMatrix.GetComponent<StrideMatrixController>().minY) / 0.02f);
		return row * 14 + column;
	}

	public void resetAnimation() {
		StopAllCoroutines ();
		destroyInputCubes ();
		destroyOutputCubes ();
		_animatingInputCubes = false;
		_animatingOutputCubes = false;

		if (_isAnimating) {
			startAnimating ();
		}
	}
}
