using UnityEngine;
using System.Collections;

public class Convolution2AnimationController : MonoBehaviour {
	private bool _isAnimating = false;
	public GameObject CubeAnimationObject;
	public GameObject down1Layer;
	public GameObject conv2Layer;
	public GameObject conv2Filters;

	private GameObject[] inputMatrices = new GameObject[16];
	private GameObject[] outputCubes = new GameObject[16];
	private bool _animatingInputCubes = false;
	private bool _animatingOutputCubes = false;

	void Update () {
		if (_isAnimating) {
			if (_animatingInputCubes) {
				if (!inputMatrices [15].GetComponent<CubeAnimationController> ().isAnimating) {
					_animatingInputCubes = false;
					destroyInputCubes ();
					createOutputCubes ();
					animateOutputCubes ();
				}
			}
			if (_animatingOutputCubes) {
				if (!outputCubes [15].GetComponent<CubeAnimationController> ().isAnimating) {
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

	private void createInputCubes() {
		GameObject[] strideMatrices = GameObject.FindGameObjectsWithTag ("strideMatrix");
		int[] cubePositions = strideMatrixToCubePositions (strideMatrices[0]);
		for (int i = 0; i < 16; i++) {
			GameObject cubeAnimationObject = Instantiate (CubeAnimationObject, down1Layer.transform.position, down1Layer.transform.rotation) as GameObject;
			for (int j = 0; j < 6; j++) {
				if (conv2Filters.transform.GetChild (i).GetChild (j).childCount > 0) {
					for (int k = 0; k < cubePositions.Length; k++) {
						GameObject cube = down1Layer.transform.GetChild (j).GetChild (cubePositions [k]).gameObject;
						GameObject cubeClone = Instantiate (cube) as GameObject;
						cubeClone.transform.parent = cubeAnimationObject.transform;
						cubeClone.transform.localPosition = conv2Filters.transform.GetChild (i).GetChild (j).GetChild (k).localPosition;
						cubeClone.transform.localRotation = conv2Filters.transform.GetChild (i).GetChild (j).GetChild (k).localRotation;
					}
				}
			}
			inputMatrices [i] = cubeAnimationObject;
		}
	}

	private void animateInputCubes() {
		_animatingInputCubes = true;
		for (int i = 0; i < 16; i++) {
			Vector3 moveToPosition = conv2Filters.transform.GetChild (i).position;
			Quaternion moveToRotation = conv2Filters.transform.GetChild (i).rotation;

			StartCoroutine (inputMatrices[i].GetComponent<CubeAnimationController> ().moveToPosition (moveToPosition, moveToRotation, 5f));
		}
	}

	private void destroyInputCubes() {
		for (int i = 0; i < 16; i++) {
			Destroy (inputMatrices [i]);
		}
	}

	private void createOutputCubes() {
		for (int i = 0; i < 16; i++) {
			GameObject strideMatrix = GameObject.FindGameObjectsWithTag ("smallStrideMatrix")[i];
			int cubeIndex = strideMatrixToCubePosition (strideMatrix);
			GameObject cube = conv2Layer.transform.GetChild (i).GetChild (cubeIndex).gameObject;

			Vector3 startPosition = conv2Filters.transform.GetChild (i).position;
			Quaternion startRotation = conv2Filters.transform.GetChild (i).rotation;
			GameObject cubeClone = Instantiate (cube, startPosition, startRotation) as GameObject;
			GameObject cubeAnimator = Instantiate (CubeAnimationObject, startPosition, startRotation) as GameObject;
			cubeClone.transform.parent = cubeAnimator.transform;
			outputCubes [i] = cubeAnimator;
		}
	}

	private void destroyOutputCubes() {
		for (int i = 0; i < 16; i++) {
			Destroy (outputCubes [i]);
		}
	}

	private void animateOutputCubes() {
		_animatingOutputCubes = true;
		for (int i = 0; i < 16; i++) {
			GameObject strideMatrix = GameObject.FindGameObjectsWithTag ("smallStrideMatrix")[i];
			int cubeIndex = strideMatrixToCubePosition (strideMatrix);
			GameObject cube = conv2Layer.transform.GetChild (i).GetChild (cubeIndex).gameObject;

			StartCoroutine(outputCubes[i].GetComponent<CubeAnimationController> ().moveToPosition (cube.transform.position, cube.transform.rotation, 5f));
		}
	}

	private int[] strideMatrixToCubePositions(GameObject strideMatrix) {
		int startColumn = Mathf.RoundToInt((strideMatrix.transform.localPosition.x - strideMatrix.GetComponent<StrideMatrixController>().minX) / 0.02f);
		int startRow = Mathf.RoundToInt((strideMatrix.transform.localPosition.y - strideMatrix.GetComponent<StrideMatrixController>().minY) / 0.02f);
		int[] cubePositions = new int[25];
		int index = 0;
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				cubePositions [index] = (startRow+i)*14 + startColumn + j;
				index++;
			}
		}
		return cubePositions;
	}

	private int strideMatrixToCubePosition(GameObject strideMatrix) {
		int column = Mathf.RoundToInt((strideMatrix.transform.localPosition.x - strideMatrix.GetComponent<StrideMatrixController>().minX) / 0.02f);
		int row = Mathf.RoundToInt((strideMatrix.transform.localPosition.y - strideMatrix.GetComponent<StrideMatrixController>().minY) / 0.02f);
		return row * 10 + column;
	}
		
}
