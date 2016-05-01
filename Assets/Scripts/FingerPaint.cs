using UnityEngine;
using System.Collections.Generic;
using Leap.Unity;
using Leap;
using System.IO;
using System.Collections;

public class FingerPaint : MonoBehaviour
{
    public HandPool handPool;
	public LeapHandController leapHandController;
    List<Vector3> linePoints;
    LineRenderer lineRenderer;
	public Transform centerEyeTransform;
    Finger finger;

    private bool fingerdetect;
	private bool isDrawing;
//    private float newPointDelta = 0.02f;
	private float newPointDelta = 0.002f;
    private Vector3 fingerTipPos;

	public const float TRIGGER_DISTANCE_RATIO = 0.7f;

	private const float NUMBER_OFF_VALUE = -0.1f;
	private const float NUMBER_ON_VALUE = 1.1749999999999998f;

	public GameController gameController;

	private Texture2D canvas;

	private int waitFrames = 0;

	public float[] numberMatrix;
	public bool numberMatrixInitialized = false;


    // Use this for initialization
    void Awake()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        lineRenderer.SetVertexCount(0);
        lineRenderer.SetWidth(0.01f, 0.01f);
        lineRenderer.SetColors(Color.green, Color.green);
		lineRenderer.useWorldSpace = true;
        fingerdetect = false;
		linePoints = new List<Vector3> ();
    }

    // Update is called once per frame
    void Update()
    {
		List<IHandModel> modelPool = handPool.ModelPool;

		Dictionary<int, HandRepresentation> graphicsHands = leapHandController.graphicsReps;
		Dictionary<int, HandRepresentation> physicsHands = leapHandController.physicsReps;

		if (graphicsHands.Count != 1) return;

		//instead of getting just one hand here... check both
		//want to trigger with one hand, draw with the other, and not flip them in the middle
		//of drawing
		//possibly 
		//clear when start drawing


//		Debug.Log ((new List<HandRepresentation>(leapHandController.graphicsReps.Values))[0]);
		HandProxy handProxy = (HandProxy) (new List<HandRepresentation>(leapHandController.graphicsReps.Values))[0];
		Hand leapHand = handProxy.handModel.GetLeapHand ();

		if (handIsTrigger (leapHand)) {
			//draw with other hand
			finger = leapHand.Fingers[(int)Finger.FingerType.TYPE_INDEX];

			fingerTipPos = finger.TipPosition.ToVector3();
			fingerdetect = true;
//		} else if (handIsTrigger (allGraphicHands [1])) {
//			finger = allGraphicHands [0].fingers [(int)Finger.FingerType.TYPE_INDEX];
//
//			fingerTipPos = finger.GetTipPosition ();
//			fingerdetect = true;
		} else if (isDrawing && linePoints.Count > 30) {
			isDrawing = false;
			fingerdetect = false;
			Debug.Log (linePoints.Count);

//			float yRotation = centerEyeTransform.localRotation.eulerAngles.y;
//
//			for (int i = 0; i < linePoints.Count; i++) {
//				linePoints [i] = Quaternion.Euler (0, -yRotation, 0) * linePoints [i];
//			}

			for (int i = 0; i < linePoints.Count; i++) {
				linePoints [i] = Quaternion.Inverse(centerEyeTransform.rotation) * linePoints [i];
			}

			//capture points and convert to matrix
			float xMin = linePoints [0].x;
			float xMax = linePoints [0].x;
			float yMin = linePoints [0].y;
			float yMax = linePoints [0].y;
			for (int i = 1; i < linePoints.Count; i++) {
				if (linePoints [i].x < xMin) {
					xMin = linePoints [i].x;
				}
				if (linePoints [i].x > xMax) {
					xMax = linePoints [i].x;
				}
				if (linePoints [i].y < yMin) {
					yMin = linePoints [i].y;
				}
				if (linePoints [i].y > yMax) {
					yMax = linePoints [i].y;
				}
			}
			//xMax - xMin is the width of the matrix, yMax - yMin is the height of the matrix
			//then quantize to 32X32?
			float xDelta = xMax - xMin;
			float yDelta = yMax - yMin;
			float yStart = 0f;
			float xStart = 0f;

			Debug.Log ("xDelta: " + xDelta);
			Debug.Log ("yDelta: " + yDelta);

			int canvasSize = 250;
			int canvasPadding = 20;
//			if (xDelta > yDelta) {
//				yStart = (xDelta - yDelta) / 2;
//				canvas = new Texture2D (Mathf.CeilToInt(xDelta*canvasSize)+50, Mathf.CeilToInt(xDelta*canvasSize)+50);
//			} else {
//				xStart = (yDelta - xDelta) / 2;
//				canvas = new Texture2D (Mathf.CeilToInt(yDelta*canvasSize)+50, Mathf.CeilToInt(yDelta*canvasSize)+50);
//			}

			canvas = new Texture2D (canvasSize+canvasPadding, canvasSize+canvasPadding);

			for (int i = 0; i < canvas.width; i++) {
				for (int j = 0; j < canvas.height; j++) {
					canvas.SetPixel (i, j, Color.black);
				}
			}
			canvas.Apply ();

			numberMatrix = new float[1024];
			for (int i = 0; i < 1024; i++) {
				numberMatrix [i] = NUMBER_OFF_VALUE;
			}

			Debug.Log ("yMin: " + yMin);
			Debug.Log ("xMin: " + xMin);
			Debug.Log ("yMax: " + yMax);
			Debug.Log ("xMax: " + xMax);

			for (int i = 0; i < linePoints.Count; i++) {
				if (i + 1 < linePoints.Count) {
					int x0, y0, x1, y1;
//					if (xMin < 0) {
//						x0 = Mathf.RoundToInt ((linePoints [i].x - xMin + xStart)*canvasSize);
//						x1 = Mathf.RoundToInt ((linePoints [i + 1].x - xMin + xStart)*canvasSize);
//					} else {
//						x0 = Mathf.RoundToInt ((linePoints [i].x + xStart)*canvasSize);
//						x1 = Mathf.RoundToInt ((linePoints [i + 1].x + xStart)*canvasSize);
//					}
//
//					if (yMin < 0) {
//						y0 = Mathf.RoundToInt ((linePoints [i].y - yMin + yStart)*canvasSize);
//						y1 = Mathf.RoundToInt ((linePoints [i + 1].y - yMin + yStart)*canvasSize);
//					} else {
//						y0 = Mathf.RoundToInt ((linePoints [i].y + yStart)*canvasSize);
//						y1 = Mathf.RoundToInt ((linePoints [i + 1].y + yStart)*canvasSize);
//					}

					if (yDelta > xDelta) {
						x0 = Mathf.RoundToInt (((linePoints [i].x - xMin + xStart)/yDelta)*canvasSize) + canvasPadding/2;
						x1 = Mathf.RoundToInt (((linePoints [i+1].x -xMin + xStart)/yDelta)*canvasSize) + canvasPadding/2;
					} else {
						x0 = Mathf.RoundToInt (((linePoints [i].x - xMin)/xDelta)*canvasSize) + canvasPadding/2;
						x1 = Mathf.RoundToInt (((linePoints [i + 1].x - xMin)/xDelta)*canvasSize) + canvasPadding/2;
					}

					if (yDelta > xDelta) {
						y0 = Mathf.RoundToInt (((linePoints [i].y - yMin)/yDelta)*canvasSize) + canvasPadding/2;
						y1 = Mathf.RoundToInt (((linePoints [i + 1].y - yMin)/yDelta)*canvasSize) + canvasPadding/2;
					} else {
						y0 = Mathf.RoundToInt (((linePoints [i].y - yMin + yStart)/xDelta)*canvasSize) + canvasPadding/2;
						y1 = Mathf.RoundToInt (((linePoints [i + 1].y -yMin + yStart)/xDelta)*canvasSize) + canvasPadding/2;
					}

					for (int j = -8; j < 9; j++) {
						for (int k = -8; k < 9; k++) {
							DrawLine (canvas, x0+j, y0+k, x1+j, y1+k, Color.white);
						}
					}
				}
					
//				float x = map (linePoints[i].x, xMin - xStart, xMax + xStart, 2.0f, 29.0f);
//				int xVal = Mathf.RoundToInt(x);
//				float y = map(linePoints[i].y, yMin - yStart, yMax + yStart, 2.0f, 29.0f);
//				int yVal = Mathf.RoundToInt(y);
//
//				numberMatrix [32 * xVal + yVal] = NUMBER_ON_VALUE;
			}
				
			canvas.Apply ();
			//to debug canvas
			byte[] bytes = canvas.EncodeToPNG();
			Object.Destroy(canvas);
			File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

			TextureScale.Bilinear (canvas, 28, 28);
			canvas.Apply ();
			for (int i = 27; i >= 0; i--) {
				for (int j = 0; j < 28; j++) {
//					numberMatrix [32 * (27-i) + j + 2] = canvas.GetPixel (i, j).r * 1.275f - 0.1f;
					numberMatrix [(32 * (i + 2)) + j + 2] = canvas.GetPixel (i, j).r * 1.275f - 0.1f;
				}
			}

//			//to debug downsampled canvas
//			byte[] bytes = canvas.EncodeToPNG();
//			Object.Destroy(canvas);
//			File.WriteAllBytes(Application.dataPath + "/../SavedScreen.png", bytes);

			//then send to server
			if (gameController.gameState == GameController.GameState.Full) {
				StartCoroutine(gameController.postNumber(numberMatrix));
			}

			numberMatrixInitialized = true;

		} else {
			isDrawing = false;
			fingerdetect = false;
		}
			
        if (fingerdetect)
        {
//			StartCoroutine(drawLine(isDrawing, fingerdetect));
			if (!isDrawing) {
				linePoints.Clear ();
				waitFrames = 0;
				isDrawing = true;
			}

			if (waitFrames < 5) {
				waitFrames += 1;
				return;
			}
            // Using named temp variables like this helps me think more clearly about the code
            Vector3 previousPoint = (linePoints.Count > 0) ? linePoints[linePoints.Count - 1] : new Vector3(-1000, -1000, -1000); // If you've never seen this before, it's called a ternary expression.
                                                                                                       // It's just an if/else collapsed into a single line of code. 
                                                                                                        // Also, the crazy out of bounds initial value here ensures the starting point will always draw.

            if (Vector3.Distance(fingerTipPos, previousPoint) > newPointDelta)
            {
                linePoints.Add(fingerTipPos);
                lineRenderer.SetVertexCount(linePoints.Count);
                lineRenderer.SetPosition(linePoints.Count - 1, (Vector3)linePoints[linePoints.Count - 1]);
                Debug.Log(string.Format("Added point at: {0}!", fingerTipPos));
            }
        }
    }

	bool handIsTrigger(Hand leapHand) {

		bool isTrigger = false;

		//if drawing, if one or two fingers is extended, keep drawing
		if (isDrawing) {
			bool indexExtended = leapHand.Fingers [(int)Finger.FingerType.TYPE_INDEX].IsExtended;
			int numOtherFingersExtended = 0;

			if (leapHand.Fingers [(int)Finger.FingerType.TYPE_THUMB].IsExtended) {
				numOtherFingersExtended += 1;
			}

			if (leapHand.Fingers [(int)Finger.FingerType.TYPE_MIDDLE].IsExtended) {
				numOtherFingersExtended += 1;
			}

			if (leapHand.Fingers [(int)Finger.FingerType.TYPE_RING].IsExtended) {
				numOtherFingersExtended += 1;
			}

			if (leapHand.Fingers [(int)Finger.FingerType.TYPE_PINKY].IsExtended) {
				numOtherFingersExtended += 1;
			}

			if (numOtherFingersExtended <= 1 && indexExtended) {
				isTrigger = true;
			}
		} else {
			isTrigger = leapHand.Fingers [(int)Finger.FingerType.TYPE_INDEX].IsExtended
				&& !leapHand.Fingers [(int)Finger.FingerType.TYPE_THUMB].IsExtended
				&& !leapHand.Fingers [(int)Finger.FingerType.TYPE_MIDDLE].IsExtended
				&& !leapHand.Fingers [(int)Finger.FingerType.TYPE_RING].IsExtended
				&& !leapHand.Fingers [(int)Finger.FingerType.TYPE_PINKY].IsExtended;
		}
			
//		// Scale trigger distance by thumb proximal bone length.
//		Vector leap_thumb_tip = leapHand.Fingers[(int)Finger.FingerType.TYPE_THUMB].TipPosition;
//		float proximal_length = leapHand.Fingers[(int)Finger.FingerType.TYPE_THUMB].Bone(Bone.BoneType.TYPE_PROXIMAL).Length;
//		float trigger_distance = proximal_length * TRIGGER_DISTANCE_RATIO;
//
//		//check distance between index & thumb
//		Vector leap_index_tip = leapHand.Fingers[(int)Finger.FingerType.TYPE_INDEX].TipPosition;
//		if (leap_index_tip.DistanceTo (leap_thumb_tip) < trigger_distance) {
//			isTrigger = true;
//			Debug.Log ("Thumb and index touching!");
//		}
		return isTrigger;
	}

	float map(float s, float a1, float a2, float b1, float b2)
	{
		return b1 + (s-a1)*(b2-b1)/(a2-a1);
	}

	void DrawLine(Texture2D tex, int x0, int y0, int x1, int y1, Color col)
	{
		int dy = (int)(y1-y0);
		int dx = (int)(x1-x0);
		int stepx, stepy;

		if (dy < 0) {dy = -dy; stepy = -1;}
		else {stepy = 1;}
		if (dx < 0) {dx = -dx; stepx = -1;}
		else {stepx = 1;}
		dy <<= 1;
		dx <<= 1;

		float fraction = 0;

		tex.SetPixel(x0, y0, col);
		if (dx > dy) {
			fraction = dy - (dx >> 1);
			while (Mathf.Abs(x0 - x1) > 1) {
				if (fraction >= 0) {
					y0 += stepy;
					fraction -= dx;
				}
				x0 += stepx;
				fraction += dy;
				tex.SetPixel(x0, y0, col);
			}
		}
		else {
			fraction = dx - (dy >> 1);
			while (Mathf.Abs(y0 - y1) > 1) {
				if (fraction >= 0) {
					x0 += stepx;
					fraction -= dy;
				}
				y0 += stepy;
				fraction += dx;
				tex.SetPixel(x0, y0, col);
			}
		}
	}
}