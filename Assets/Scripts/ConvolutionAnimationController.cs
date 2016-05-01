using UnityEngine;
using System.Collections;

public class ConvolutionAnimationController : MonoBehaviour {
	private bool _isAnimating = false;
	public GameObject CubeAnimationObject;
	public GameObject conv1Filters;

	private GameObject[] inputMatrices = new GameObject[6];
	private GameObject[] outputCubes = new GameObject[6];
	private bool _animatingInputCubes = false;
	private bool _animatingOutputCubes = false;

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
			//map strideMatrix positions to cube positions
			//if haven't started yet, or just ended
			//make six copies of inputMatrix and start animating to each filter
			//when hit filter, delete them
			//get cube in each output stride matrix, make a copy of it, put it at filter position
			//animate it to current stride matrix position
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

	private int[] strideMatrixPositionToCubePositions(Vector3 strideMatrixPosition) {
		int startRow = Mathf.RoundToInt((strideMatrixPosition.y + 0.27f) / 0.02f);
		int startColumn = Mathf.RoundToInt((strideMatrixPosition.x + 0.27f) / 0.02f);

		int[] cubePositions = new int[25];
		int index = 0;
		for (int i = 0; i < 5; i++) {
			for (int j = 0; j < 5; j++) {
				cubePositions [index] = (startRow+i)*32 + startColumn + j;
				index++;
			}
		}
		return cubePositions;
	}

	private int strideMatrixPositionToCubePosition(Vector3 strideMatrixPosition) {
		int row = Mathf.RoundToInt((strideMatrixPosition.y + 0.27f) / 0.02f);
		int column = Mathf.RoundToInt((strideMatrixPosition.x + 0.27f) / 0.02f);
		return row * 28 + column;
	}

	private void createInputCubes() {
		GameObject strideMatrix = GameObject.FindGameObjectWithTag ("strideMatrix");
		int[] cubePositions = strideMatrixPositionToCubePositions (strideMatrix.transform.localPosition);
		GameObject inputMatrix = Instantiate(CubeAnimationObject, strideMatrix.transform.position, strideMatrix.transform.rotation) as GameObject;
		inputMatrix.name = "InputConvolutionMatrix";
		for (int i = 0; i < cubePositions.Length; i++) {
			GameObject cube = GameObject.FindGameObjectWithTag ("image").transform.GetChild (cubePositions [i]).gameObject;
			GameObject cubeClone = Instantiate (cube, cube.transform.position, cube.transform.rotation) as GameObject;
			cubeClone.transform.parent = inputMatrix.transform;
		}

		inputMatrices = new GameObject[6];
		for (int i = 0; i < 6; i++) {
			GameObject inputMatrixClone = Instantiate (inputMatrix);
			inputMatrices [i] = inputMatrixClone;
		}

		Destroy (inputMatrix);

//		Vector3 moveToPosition = conv1Filters.transform.GetChild (0).GetChild (12).transform.position;
//		moveToPosition.y = 0.3f;
//		Quaternion moveToRotation = conv1Filters.transform.GetChild (0).GetChild (12).transform.rotation;
//
//		StartCoroutine(inputMatrix.GetComponent<InputConvolutionMatricesController> ().moveToPosition (moveToPosition, moveToRotation, 5f));

	}

	private void animateInputCubes() {
		_animatingInputCubes = true;
		for (int i = 0; i < 6; i++) {
			Vector3 moveToPosition = conv1Filters.transform.GetChild (i).GetChild (12).transform.position;
//			moveToPosition.y = 0.3f;
			Quaternion moveToRotation = conv1Filters.transform.GetChild (i).GetChild (12).transform.rotation;
//			moveToRotation = Quaternion.Euler (moveToRotation.eulerAngles.x, moveToRotation.eulerAngles.y + 180, moveToRotation.eulerAngles.z);

			StartCoroutine(inputMatrices[i].GetComponent<CubeAnimationController> ().moveToPosition (moveToPosition, moveToRotation, 5f));
		}
	}

	private void destroyInputCubes() {
		for (int i = 0; i < 6; i++) {
			Destroy (inputMatrices [i]);
		}
	}

	private void createOutputCubes() {
		GameObject strideMatrix = GameObject.FindGameObjectWithTag ("strideMatrix");
		int cubeIndex = strideMatrixPositionToCubePosition (strideMatrix.transform.localPosition);
		outputCubes = new GameObject[6];
		GameObject conv1Output = GameObject.FindGameObjectWithTag ("conv1");
		for (int i = 0; i < 6; i++) {
			Vector3 position = conv1Filters.transform.GetChild (i).GetChild (12).transform.position;
//			position.y = 0.3f;
			Quaternion rotation = conv1Filters.transform.GetChild (i).GetChild (12).transform.rotation;
			GameObject cubeClone = Instantiate (conv1Output.transform.GetChild(i).GetChild(cubeIndex).gameObject, position, rotation) as GameObject;
			GameObject cubeAnimator = Instantiate (CubeAnimationObject, position, rotation) as GameObject;
			cubeClone.transform.parent = cubeAnimator.transform;
			outputCubes [i] = cubeAnimator;
		}

	}

	private void animateOutputCubes() {
		_animatingOutputCubes = true;
		GameObject strideMatrix = GameObject.FindGameObjectWithTag ("strideMatrix");
		int cubeIndex = strideMatrixPositionToCubePosition (strideMatrix.transform.localPosition);
		GameObject conv1Output = GameObject.FindGameObjectWithTag ("conv1");
		for (int i = 0; i < 6; i++) {
			Vector3 position = conv1Output.transform.GetChild (i).GetChild (cubeIndex).position;
			Quaternion rotation = conv1Output.transform.GetChild (i).GetChild (cubeIndex).rotation;

			StartCoroutine(outputCubes[i].GetComponent<CubeAnimationController> ().moveToPosition (position, rotation, 5f));
		}
	}

	private void destroyOutputCubes() {
		for (int i = 0; i < outputCubes.Length; i++) {
			Destroy (outputCubes [i]);
		}
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
