using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
//	string matrix = "[-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,0.535,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1349999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.05500000000000001,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,0.10499999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,0.9899999999999999,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1]";
	string matrix = "[-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,0.9799999999999999,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.065,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.065,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,0.17500000000000002,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,0.52,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,0.69,1.1749999999999998,1.1749999999999998,1.1749999999999998,0.77,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,0.29999999999999993,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,0.42499999999999993,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.17,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.13,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,0.985,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1549999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,0.375,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,0.9049999999999999,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,0.965,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,0.515,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,1.1749999999999998,0.71,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1,-0.1]";
	public string url = "http://104.236.254.218:6969";
	public string imageUrl = "http://104.236.254.218:6969/image";

	public GameObject Cube;
	public GameObject cubesObject;
	int numLayers = 8;
	int numCubes;

	float[] redLookup = new float[]{0.00f,0.01f,0.02f,0.03f,0.04f,0.05f,0.06f,0.07f,0.08f,0.08f,0.09f,0.10f,0.11f,0.12f,0.12f,0.13f,0.14f,0.14f,0.15f,0.15f,0.16f,0.16f,0.17f,0.17f,0.17f,0.17f,0.18f,0.18f,0.18f,0.18f,0.18f,0.18f,0.17f,0.17f,0.17f,0.17f,0.16f,0.16f,0.15f,0.15f,0.14f,0.14f,0.14f,0.14f,0.14f,0.14f,0.13f,0.13f,0.13f,0.13f,0.12f,0.12f,0.12f,0.12f,0.11f,0.11f,0.11f,0.10f,0.10f,0.10f,0.09f,0.09f,0.09f,0.08f,0.08f,0.08f,0.07f,0.07f,0.07f,0.06f,0.06f,0.06f,0.05f,0.05f,0.05f,0.04f,0.04f,0.04f,0.04f,0.03f,0.03f,0.03f,0.02f,0.02f,0.02f,0.02f,0.01f,0.01f,0.01f,0.01f,0.01f,0.01f,0.00f,0.00f,0.00f,0.00f,0.00f,0.00f,0.00f,0.00f};
	float[] greenLookup = new float[]{0.00f,0.01f,0.02f,0.03f,0.04f,0.05f,0.05f,0.06f,0.07f,0.08f,0.08f,0.09f,0.09f,0.10f,0.10f,0.11f,0.11f,0.12f,0.12f,0.13f,0.13f,0.13f,0.13f,0.14f,0.14f,0.14f,0.14f,0.14f,0.15f,0.15f,0.15f,0.15f,0.15f,0.15f,0.15f,0.15f,0.15f,0.15f,0.15f,0.14f,0.15f,0.15f,0.15f,0.16f,0.16f,0.17f,0.18f,0.18f,0.19f,0.20f,0.20f,0.21f,0.22f,0.23f,0.24f,0.25f,0.26f,0.27f,0.28f,0.29f,0.31f,0.32f,0.33f,0.35f,0.36f,0.37f,0.39f,0.41f,0.42f,0.44f,0.46f,0.48f,0.49f,0.51f,0.53f,0.55f,0.58f,0.60f,0.62f,0.64f,0.66f,0.69f,0.71f,0.74f,0.76f,0.79f,0.82f,0.84f,0.87f,0.90f,0.91f,0.92f,0.93f,0.94f,0.95f,0.96f,0.97f,0.98f,0.99f,1.00f};
	float[] blueLookup = new float[]{0.00f,0.01f,0.02f,0.03f,0.04f,0.05f,0.06f,0.07f,0.08f,0.09f,0.10f,0.11f,0.12f,0.13f,0.14f,0.15f,0.16f,0.17f,0.18f,0.19f,0.20f,0.21f,0.22f,0.23f,0.24f,0.25f,0.26f,0.27f,0.28f,0.29f,0.30f,0.31f,0.32f,0.33f,0.34f,0.35f,0.36f,0.37f,0.38f,0.39f,0.40f,0.41f,0.42f,0.43f,0.44f,0.45f,0.46f,0.47f,0.48f,0.49f,0.51f,0.52f,0.53f,0.54f,0.55f,0.56f,0.57f,0.58f,0.59f,0.60f,0.61f,0.62f,0.63f,0.64f,0.65f,0.66f,0.67f,0.68f,0.69f,0.70f,0.71f,0.72f,0.73f,0.74f,0.75f,0.76f,0.77f,0.78f,0.79f,0.80f,0.81f,0.82f,0.83f,0.84f,0.85f,0.86f,0.87f,0.88f,0.89f,0.90f,0.89f,0.88f,0.88f,0.87f,0.86f,0.85f,0.83f,0.82f,0.81f,0.80f};
	
	GameObject[] cubesArray;

	GameObject[] filterOneCubesArray;
	GameObject[] filterTwoCubesArray;

	float cubeScale = 500f;

	public enum GameState{Drawing, Input, Conv1, Down1, Conv2, Down2, Hidden1, Hidden2, Final, Full};
	public GameState gameState;

	public GameObject[] layers;
	public GameObject[] filters;
	public GameObject drawer;
	public GameObject downsamplePlane;
	public GameObject lines1;
	public GameObject lines2;

	public GameObject StrideMatrix;
	public GameObject SmallStrideMatrix;
	public GameObject DownStrideMatrix;
	public GameObject LineCylinder;
	public GameObject FinalValueLabel;
	public GameObject CubeLineHolder;

	public AudioClip[] audioClips;
	private int audioIndex = 0;

	public AudioClip thumbsUpReminder;

	private IEnumerator animateGreatestCube;

	Dictionary<string, int> layerToKernelSize = new Dictionary<string, int>()
	{
		{"conv1", 784},
		{"down1", 196},
		{"conv2", 100},
		{"down2", 25}
	};

	IEnumerator loadHiddenWeights() {
		layers [4].transform.localRotation = Quaternion.Euler (0, -90, 0);
		layers [4].transform.localPosition = new Vector3 (-0.6f, 0.1f, -0.5f);

		layers [5].transform.localRotation = Quaternion.Euler (0, -90, 0);
		layers [5].transform.localPosition = new Vector3 (0.6f, 0f, -0.5f);

		TextAsset hiddenWeights1text = Resources.Load<TextAsset> ("hidden_weights_1");
		string hiddenWeights1Json = hiddenWeights1text.text;
		WeightsMatrix weightsMatrix = WeightsMatrix.CreateFromJSON (hiddenWeights1Json);

		for (int i = 0; i < 16; i++) {
			GameObject kernel = new GameObject ();
			kernel.name = "Kernel" + (i + 1);
			kernel.transform.parent = lines1.transform;
			for (int j = 0; j < 25; j++) {
				GameObject cube = Instantiate (CubeLineHolder, Vector3.zero, Quaternion.identity) as GameObject;
//				GameObject cube = new GameObject ();
				cube.name = "CubeLineHolder";
				cube.GetComponent<AudioSource> ().spatialize = true;
				cube.transform.parent = kernel.transform;
				for (int k = 0; k < weightsMatrix.weights.Length; k++) {
						GameObject line = Instantiate (LineCylinder) as GameObject;
						GameObject startCube = layers [4].transform.GetChild (i).GetChild (j).gameObject;
						Vector3 startPosition = startCube.transform.position;
						Vector3 endPosition = layers [5].transform.GetChild (k).position;

						Vector3 midpoint = (endPosition + startPosition) * 0.5f;
						float distance = Vector3.Distance (startPosition, endPosition);
						Quaternion rotation = Quaternion.FromToRotation (Vector3.up, endPosition - startPosition);

						line.transform.position = midpoint;
						line.transform.localScale = new Vector3 (line.transform.localScale.x, distance / 2, line.transform.localScale.z);
						line.transform.rotation = rotation;

					int colorNum = Mathf.RoundToInt (weightsMatrix.weights [k].column[i*j] * 99);
						if (colorNum > 99) {
							colorNum = 99;
						}
						if (colorNum < 0) {
							colorNum = 0;
						}
						line.GetComponent<MeshRenderer> ().material.color = new Color (redLookup [colorNum], greenLookup [colorNum], blueLookup [colorNum], 1.0F);
					line.transform.parent = cube.transform;
					if (((i+1)*(k+1)*(j+1)) % 500 == 0) {
						yield return new WaitForSeconds (0);
					}
				}
				cube.SetActive (false);
			}
		}
		StartCoroutine(loadHiddenWeights2 ());
	}

	IEnumerator loadHiddenWeights2() {
		layers [5].transform.localRotation = Quaternion.Euler (0, -90, 0);
		layers [5].transform.localPosition = new Vector3 (-0.6f, 0.1f, -0.5f);

		layers [6].transform.localRotation = Quaternion.Euler (0, -90, 0);
		layers [6].transform.localPosition = new Vector3 (0.6f, 0f, -0.5f);

		TextAsset hiddenWeights2text = Resources.Load<TextAsset> ("hidden_weights_2");
		string hiddenWeights2Json = hiddenWeights2text.text;
		WeightsMatrix weightsMatrix = WeightsMatrix.CreateFromJSON (hiddenWeights2Json);

		for (int i = 0; i < 120; i++) {
			GameObject cube = Instantiate (CubeLineHolder, Vector3.zero, Quaternion.identity) as GameObject;
//			GameObject cube = new GameObject ();
			cube.name = "CubeLineHolder";
			cube.GetComponent<AudioSource> ().spatialize = true;
			cube.transform.parent = lines2.transform;
			for (int j = 0; j < 100; j++) {
				GameObject line = Instantiate (LineCylinder) as GameObject;
				GameObject startCube = layers [5].transform.GetChild (i).gameObject;
				Vector3 startPosition = startCube.transform.position;
				Vector3 endPosition = layers [6].transform.GetChild (j).position;

				Vector3 midpoint = (endPosition + startPosition) * 0.5f;
				float distance = Vector3.Distance (startPosition, endPosition);
				Quaternion rotation = Quaternion.FromToRotation (Vector3.up, endPosition - startPosition);

				line.transform.position = midpoint;
				line.transform.localScale = new Vector3 (line.transform.localScale.x, distance / 2, line.transform.localScale.z);
				line.transform.rotation = rotation;

				int colorNum = Mathf.RoundToInt (weightsMatrix.weights [j].column[i] * 99);
				if (colorNum > 99) {
					colorNum = 99;
				}
				if (colorNum < 0) {
					colorNum = 0;
				}
				line.GetComponent<MeshRenderer> ().material.color = new Color (redLookup [colorNum], greenLookup [colorNum], blueLookup [colorNum], 1.0F);
				line.transform.parent = cube.transform;

				if (((i+1) * (j+1)) % 500 == 0) {
					yield return new WaitForSeconds (0);
				}
			}
			cube.SetActive (false);
		}
	}


	IEnumerator Start() {
		yield return new WaitForSeconds (0);
		gameState = GameState.Drawing;
		//parse all layer positions
		TextAsset text = Resources.Load<TextAsset> ("webgl_convnet2");
		string positionsJson = text.text;
		Nodes cubes = Nodes.CreateFromJSON (positionsJson);
		numCubes = cubes.nodes.Length;
		cubesArray = new GameObject[numCubes];
		string type = "";
		Transform[] kernels = new Transform[0];
		int kernelIndex = 0;
		int kernelNodeIndex = 0;
		for (int i = 0; i < cubes.nodes.Length; i++) {
			if (!type.Equals (cubes.nodes[i].type)) {
				type = cubes.nodes [i].type;
				//new kernel
				Transform layer =  layers[cubes.nodes[i].layerNum].transform;
				int childCount = layer.childCount;
				kernelIndex = 0;
				kernels = new Transform[childCount];
				kernelNodeIndex = 0;
				if (childCount > 0) {
					for (int j = 0; j < childCount; j++) {
						kernels[j] = layer.GetChild (j);
					}
				}
			}
//			Vector3 position = new Vector3 (cubes.nodes [i].x/cubeScale, cubes.nodes [i].y/cubeScale, cubes.nodes [i].z/cubeScale); 
			Vector3 position = new Vector3 (cubes.nodes [i].x/cubeScale, cubes.nodes [i].z/cubeScale, 0); 
			GameObject instance = Instantiate (Cube, position + cubesObject.transform.position, Quaternion.identity) as GameObject;
			//if there are kernels, set parent to be kernel at kernelIndex, but first check if we need to increment kernelIndex by one
			//if kernelNodeIndex is greater than the size of one kernel
			if (kernels.Length > 0) {
				if (kernelNodeIndex >= layerToKernelSize [type]) {
					kernelNodeIndex = 0;
					kernelIndex++;
				}
				instance.transform.parent = kernels [kernelIndex];
			} else {
				instance.transform.parent = layers[cubes.nodes[i].layerNum].transform;
			}
			cubesArray [i] = instance;
			kernelNodeIndex++;

			if (i % 1000 == 0) {
				yield return new WaitForSeconds (0);
			}
		}

		//parse filter one positions and values
		TextAsset filterOneText = Resources.Load<TextAsset>("filter1_positions");
		string filterOnePositionsJson = filterOneText.text;
		Nodes filterOneCubes = Nodes.CreateFromJSON (filterOnePositionsJson);
		int numFilterOneCubes = filterOneCubes.nodes.Length;
		filterOneCubesArray = new GameObject[numFilterOneCubes];
		Transform convFilter1 = filters[0].transform;
		kernels = new Transform[6];
		for (int j = 0; j < 6; j++) {
			kernels [j] = convFilter1.GetChild (j);
		}
		kernelIndex = 0;
		kernelNodeIndex = 0;
		for (int i = 0; i < numFilterOneCubes; i++) {
//			Vector3 position = new Vector3 (filterOneCubes.nodes [i].x/cubeScale, filterOneCubes.nodes [i].y/cubeScale, filterOneCubes.nodes [i].z/cubeScale);
			Vector3 position = new Vector3 (filterOneCubes.nodes [i].x/cubeScale, filterOneCubes.nodes [i].z/cubeScale, 0);
			GameObject instance = Instantiate (Cube, position +cubesObject.transform.position, Quaternion.identity) as GameObject;
			if (kernelNodeIndex >= 25) {
				kernelNodeIndex = 0;
				kernelIndex++;
			}
			instance.transform.parent = convFilter1.GetChild (kernelIndex);
			int colorNum = Mathf.RoundToInt(filterOneCubes.nodes[i].value*99);
			instance.GetComponent<MeshRenderer> ().material.color = new Color (redLookup[colorNum], greenLookup[colorNum], blueLookup[colorNum], 1.0F);
			instance.GetComponent<CubeController> ().value = filterOneCubes.nodes [i].value;
			filterOneCubesArray [i] = instance;

			kernelNodeIndex++;
		}
		yield return new WaitForSeconds (0);

		//parse filter two positions and values
		TextAsset filterTwoText = Resources.Load<TextAsset> ("filter2_positions");
		string filterTwoPositionsJson = filterTwoText.text;
		Nodes filterTwoCubes = Nodes.CreateFromJSON (filterTwoPositionsJson);
		int numFilterTwoCubes = filterTwoCubes.nodes.Length;
		filterTwoCubesArray = new GameObject[numFilterTwoCubes];
		Transform convFilter2 = filters[1].transform;
		for (int i = 0; i < numFilterTwoCubes; i++) {
//			Vector3 position = new Vector3 (filterTwoCubes.nodes [i].x/cubeScale, filterTwoCubes.nodes [i].y/cubeScale, filterTwoCubes.nodes [i].z/cubeScale);
			Vector3 position = new Vector3 (filterTwoCubes.nodes [i].x/cubeScale, filterTwoCubes.nodes [i].z/cubeScale, 0);
			GameObject instance = Instantiate (Cube, position + cubesObject.transform.position, Quaternion.identity) as GameObject;
			int convNode = filterTwoCubes.nodes [i].convNode;
			int inputNode = filterTwoCubes.nodes [i].inputNode;

			instance.transform.parent = convFilter2.GetChild(convNode).GetChild(inputNode);
			int colorNum = Mathf.RoundToInt (filterTwoCubes.nodes [i].value * 99);
			if (colorNum > 99) {
				colorNum = 99;
			}
			instance.GetComponent<MeshRenderer>().material.color = new Color (redLookup[colorNum], greenLookup[colorNum], blueLookup[colorNum], 1.0F);
			instance.GetComponent<CubeController> ().value = filterTwoCubes.nodes [i].value;
			filterTwoCubesArray [i] = instance;
		}
		yield return new WaitForSeconds (0);
			
			
		convFilter1.localRotation = Quaternion.Euler (0, 0, 180);
		convFilter1.localPosition = new Vector3 (0, -450, 0);
		convFilter2.localRotation = Quaternion.Euler (0, 0, 180);

		convFilter1.gameObject.SetActive (false);
		convFilter2.gameObject.SetActive (false);

		StartCoroutine(loadHiddenWeights ());

		lines1.SetActive (false);
		lines2.SetActive (false);

		StartCoroutine (playCurrentAudioClip ());
	}

	public IEnumerator postNumber(float[] numberMatrix) {
		string matrixString = "[";
		for (int i = 0; i < numberMatrix.Length; i++) {
			if (i == numberMatrix.Length - 1) {
				matrixString += numberMatrix [i].ToString () + "]";
			} else {
				matrixString += numberMatrix [i].ToString () + ", ";
			}
		}
		WWWForm form = new WWWForm();
		form.AddField("matrix", matrixString);
		WWW w = new WWW(imageUrl, form);
		Debug.Log ("Making request to server!");
		yield return w;
		Debug.Log (w.text);
		NodeOutputs nodeOutputsWrapper = JsonUtility.FromJson<NodeOutputs>(w.text);
		float[] nodeOutputs = nodeOutputsWrapper.nodeOutputs;

		yield return new WaitForSeconds (0);
		for (int i = 0; i < numCubes; i++) {
			int colorNum = Mathf.RoundToInt(nodeOutputs[i]*99);
			if (colorNum > 99) {
				colorNum = 99;
			}
			if (colorNum < 0) {
				colorNum = 0;
			}
			cubesArray[i].GetComponent<MeshRenderer> ().material.color = new Color (redLookup[colorNum], greenLookup[colorNum], blueLookup[colorNum], 1.0F);
			cubesArray [i].GetComponent<CubeController> ().value = nodeOutputs [i];

			if (i % 1000 == 0) {
				yield return new WaitForSeconds (0);
			}
		}

		cubesObject.transform.GetChild (0).gameObject.SetActive (true);

		clearInputValueLabels ();

//		nextState ();
	}
		

	void Update () {
		if (Input.GetKeyDown (KeyCode.N)) {
			nextState ();
		}
		if (Input.GetKeyDown(KeyCode.P)) {
			previousState();
		}
	}

	public void nextState() {
		if (gameState == GameState.Drawing) {
			if (!drawer.GetComponent<FingerPaint> ().numberMatrixInitialized) {
				return;
			}
		}
		if (gameState != GameState.Full) {
			gameState++;
			audioIndex++;
			StartCoroutine (playCurrentAudioClip ());
		}
			
		if (gameState == GameState.Input) {
			StartCoroutine(postNumber(drawer.GetComponent<FingerPaint>().numberMatrix));
			drawer.SetActive (false);
			layers [0].SetActive (true);
			layers [0].transform.localRotation = Quaternion.Euler (0, 180, 0);
		} else if (gameState == GameState.Conv1) {
			//set all children of the cubes of input to be inactive
			layers [0].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [0].transform.localPosition = new Vector3 (-0.6f, 0.1f, -0.6f);

			layers [1].SetActive (true);
			layers [1].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [1].transform.localPosition = new Vector3 (0.6f, 0f, -0.6f);

			filters [0].transform.localPosition = new Vector3 (0.1f, 0f, -0.6f);
			filters [0].transform.localRotation = Quaternion.Euler (0, -90, 0);
			filters [0].SetActive (true);

			for (int i = 0; i < 6; i++) {
				filters [0].transform.GetChild (i).localPosition = new Vector3 (0.25f, 0.25f, -0.2f);
			}

			GameObject strideMatrix = Instantiate (StrideMatrix, layers [0].transform.position, layers [0].transform.rotation) as GameObject;
			strideMatrix.transform.parent = layers [0].transform;
			strideMatrix.transform.localPosition = new Vector3 (-0.27f, 0.27f, 0);
			strideMatrix.GetComponent<StrideMatrixController> ().setInitialPosition (new Vector3 (-0.27f, 0.27f, 0));

			for (int i = 0; i < 6; i++) {
				Transform kernel = layers [1].transform.GetChild (i);
				GameObject smallStrideMatrix = Instantiate (SmallStrideMatrix, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				smallStrideMatrix.transform.parent = kernel;

				smallStrideMatrix.transform.localPosition = new Vector3 (1.33f - 0.64f * i, 0.27f, 0);
				smallStrideMatrix.transform.localRotation = Quaternion.identity;
				smallStrideMatrix.GetComponent<StrideMatrixController> ().canDrag = false;
			}

			strideMatrix.GetComponent<StrideMatrixController> ().attachedMatrices = GameObject.FindGameObjectsWithTag ("smallStrideMatrix");

			clearInputValueLabels ();
			GetComponent<ConvolutionAnimationController> ().startAnimating ();

		} else if (gameState == GameState.Down1) {
			GetComponent<ConvolutionAnimationController> ().stopAnimating ();
			GetComponent<ConvolutionAnimationController> ().resetAnimation ();
			Destroy(GameObject.FindGameObjectWithTag("strideMatrix"));

			GameObject[] smallStrideMatrices = GameObject.FindGameObjectsWithTag ("smallStrideMatrix");

			for (int i = 0; i < smallStrideMatrices.Length; i++) {
				Destroy (smallStrideMatrices [i]);
			}

			layers [0].SetActive (false);
			layers [1].SetActive (true);
			layers [2].SetActive (true);

			layers [1].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [1].transform.localPosition = new Vector3 (-0.6f, 0.1f, -0.5f);

			layers [2].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [2].transform.localPosition = new Vector3 (0.6f, 0f, -0.5f);


			for (int i = 0; i < 6; i++) {
				Transform kernel = layers [1].transform.GetChild (i);
				GameObject downStrideMatrix = Instantiate (DownStrideMatrix, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				downStrideMatrix.transform.parent = kernel;

				downStrideMatrix.transform.localPosition = new Vector3 (1.34f - 0.64f * i, 0.26f, 0);
				downStrideMatrix.transform.localRotation = Quaternion.identity;
				downStrideMatrix.GetComponent<StrideMatrixController> ().setInitialPosition (new Vector3 (1.34f - 0.64f * i, 0.26f, 0));
			}

			GameObject[] newSmallStrideMatrices = new GameObject[6];
			for (int i = 0; i < 6; i++) {
				Transform kernel = layers [2].transform.GetChild (i);
				GameObject smallStrideMatrix = Instantiate (SmallStrideMatrix, Vector3.zero, Quaternion.identity) as GameObject;
				smallStrideMatrix.transform.parent = kernel;

				smallStrideMatrix.transform.localPosition = new Vector3 (1.47f - 0.64f * i, 0.13f, 0f);
				smallStrideMatrix.transform.localRotation = Quaternion.identity;
				smallStrideMatrix.GetComponent<StrideMatrixController> ()._strideRange = 0.26f;
				smallStrideMatrix.GetComponent<StrideMatrixController> ().setInitialPosition (new Vector3 (1.47f - 0.64f * i, 0.13f, 0f));
				smallStrideMatrix.GetComponent<StrideMatrixController> ().canDrag = false;
				newSmallStrideMatrices [i] = smallStrideMatrix;
			}
				
			GameObject[] downStrideMatrices = GameObject.FindGameObjectsWithTag ("downStrideMatrix");
			for (int i = 0; i < 6; i++) {
				GameObject[] attachedMatrices = new GameObject[newSmallStrideMatrices.Length + downStrideMatrices.Length];
				newSmallStrideMatrices.CopyTo (attachedMatrices, 0);
				downStrideMatrices.CopyTo (attachedMatrices, newSmallStrideMatrices.Length);
				downStrideMatrices [i].GetComponent<StrideMatrixController> ().attachedMatrices = attachedMatrices;
			}
			filters [0].SetActive (false);

			downsamplePlane.SetActive (true);

			GetComponent<DownsampleAnimationController> ().startAnimating ();
		} else if (gameState == GameState.Conv2) {
			GetComponent<DownsampleAnimationController> ().stopAnimating ();
			GetComponent<DownsampleAnimationController> ().resetAnimation ();
			GameObject[] downStrideMatrices = GameObject.FindGameObjectsWithTag ("downStrideMatrix");
			for (int i = 0; i < downStrideMatrices.Length; i++) {
				Destroy (downStrideMatrices [i]);
			}

			GameObject[] smallStrideMatrices = GameObject.FindGameObjectsWithTag ("smallStrideMatrix");
			for (int i = 0; i < smallStrideMatrices.Length; i++) {
				Destroy (smallStrideMatrices [i]);
			}

			layers [1].SetActive (false);
			layers [2].SetActive (true);
			layers [3].SetActive (true);
			downsamplePlane.SetActive (false);

			layers [2].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [2].transform.localPosition = new Vector3 (-0.6f, 0.1f, -0.5f);

			layers [3].transform.localRotation = Quaternion.Euler (0, -90, -90);
			layers [3].transform.localPosition = new Vector3 (0.6f, 0f, -0.5f);

			filters [1].SetActive (true);
			filters [1].transform.localPosition = new Vector3 (0.3f, -2.05f, -0.6f);
			filters [1].transform.localRotation = Quaternion.Euler (0, -90, 0);
			for (int i = 0; i < filters [1].transform.childCount; i++) {
				filters [1].transform.GetChild (i).localPosition = new Vector3 (0, 0.28f * i, 0);
			}

			GameObject[] newSmallStrideMatrices = new GameObject[16];
			//make small stride matrices on new conv layer
			for (int i = 0; i < 16; i++) {
				Transform kernel = layers [3].transform.GetChild (i);
				GameObject smallStrideMatrix = Instantiate (SmallStrideMatrix) as GameObject;
				smallStrideMatrix.transform.parent = kernel;

				smallStrideMatrix.transform.localPosition = new Vector3 (2.01f - 0.28f * i, 0.09f, 0);
				smallStrideMatrix.transform.localRotation = Quaternion.identity;

				smallStrideMatrix.GetComponent<StrideMatrixController> ()._strideRange = 0.18f;
				smallStrideMatrix.GetComponent<StrideMatrixController> ().setInitialPosition (new Vector3 (2.01f - 0.28f * i, 0.09f, 0));
				smallStrideMatrix.GetComponent<StrideMatrixController> ().canDrag = false;
				newSmallStrideMatrices [i] = smallStrideMatrix;
			}

			GameObject[] newStrideMatrices = new GameObject[6];
			for (int i = 0; i < 6; i++) {
				Transform kernel = layers [2].transform.GetChild (i);
				GameObject strideMatrix = Instantiate (StrideMatrix) as GameObject;
				strideMatrix.transform.parent = kernel;

				strideMatrix.transform.localPosition = new Vector3 (1.51f - 0.64f * i, 0.09f, 0);
				strideMatrix.transform.localRotation = Quaternion.identity;

				strideMatrix.GetComponent<StrideMatrixController> ()._strideRange = 0.18f;
				strideMatrix.GetComponent<StrideMatrixController> ().setInitialPosition (new Vector3 (1.51f - 0.64f * i, 0.09f, 0));
				newStrideMatrices [i] = strideMatrix;
			}

			for (int i = 0; i < 6; i++) {
				GameObject[] attachedMatrices = new GameObject[newSmallStrideMatrices.Length + newStrideMatrices.Length];
				newSmallStrideMatrices.CopyTo (attachedMatrices, 0);
				newStrideMatrices.CopyTo (attachedMatrices, newSmallStrideMatrices.Length);
				newStrideMatrices [i].GetComponent<StrideMatrixController> ().attachedMatrices = attachedMatrices;
			}

			GetComponent<Convolution2AnimationController> ().startAnimating ();
				
		} else if (gameState == GameState.Down2) {
			GetComponent<Convolution2AnimationController> ().stopAnimating ();
			GetComponent<Convolution2AnimationController> ().resetAnimation ();
			GameObject[] smallStrideMatrices = GameObject.FindGameObjectsWithTag ("smallStrideMatrix");

			for (int i = 0; i < smallStrideMatrices.Length; i++) {
				Destroy (smallStrideMatrices [i]);
			}


			GameObject[] strideMatrices = GameObject.FindGameObjectsWithTag ("strideMatrix");

			for (int i = 0; i < strideMatrices.Length; i++) {
				Destroy (strideMatrices [i]);
			}

			downsamplePlane.SetActive (true);
			layers [2].SetActive (false);
			layers [3].SetActive (true);
			layers [4].SetActive (true);
			filters [1].SetActive (false);


			layers [3].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [3].transform.localPosition = new Vector3 (-0.6f, 0.1f, -0.5f);

			layers [4].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [4].transform.localPosition = new Vector3 (0.6f, 0f, -0.5f);

			GameObject[] newDownStrideMatrices = new GameObject[16];
			for (int i = 0; i < 16; i++) {
				Transform kernel = layers [3].transform.GetChild (i);
				GameObject downStrideMatrix = Instantiate (DownStrideMatrix, new Vector3 (0, 0, 0), Quaternion.identity) as GameObject;
				downStrideMatrix.transform.parent = kernel;

				downStrideMatrix.transform.localPosition = new Vector3 (2.02f - 0.28f * i, 0.08f, 0);
				downStrideMatrix.transform.localRotation = Quaternion.identity;
				downStrideMatrix.GetComponent<StrideMatrixController> ()._strideRange = 0.16f;
				downStrideMatrix.GetComponent<StrideMatrixController> ()._strideStep = 0.04f;
				downStrideMatrix.GetComponent<StrideMatrixController> ().setInitialPosition (new Vector3 (2.02f - 0.28f * i, 0.08f, 0));
				newDownStrideMatrices [i] = downStrideMatrix;
			}

			GameObject[] newSmallStrideMatrices = new GameObject[16];
			for (int i = 0; i < 16; i++) {
				Transform kernel = layers [4].transform.GetChild (i);
				GameObject smallStrideMatrix = Instantiate (SmallStrideMatrix, Vector3.zero, Quaternion.identity) as GameObject;
				smallStrideMatrix.transform.parent = kernel;

				smallStrideMatrix.transform.localPosition = new Vector3 (2.06f - 0.28f * i, 0.04f, 0f);
				smallStrideMatrix.transform.localRotation = Quaternion.identity;
				smallStrideMatrix.GetComponent<StrideMatrixController> ()._strideRange = 0.08f;
				smallStrideMatrix.GetComponent<StrideMatrixController> ().setInitialPosition (new Vector3 (2.06f - 0.28f * i, 0.04f, 0f));
				smallStrideMatrix.GetComponent<StrideMatrixController> ().canDrag = false;
				newSmallStrideMatrices [i] = smallStrideMatrix;
			}

			for (int i = 0; i < 16; i++) {
				GameObject[] attachedMatrices = new GameObject[newSmallStrideMatrices.Length + newDownStrideMatrices.Length];
				newSmallStrideMatrices.CopyTo (attachedMatrices, 0);
				newDownStrideMatrices.CopyTo (attachedMatrices, newSmallStrideMatrices.Length);
				newDownStrideMatrices [i].GetComponent<StrideMatrixController> ().attachedMatrices = attachedMatrices;
			}

			GetComponent<Downsample2AnimationController> ().startAnimating ();

		} else if (gameState == GameState.Hidden1) {
			GetComponent<Downsample2AnimationController> ().stopAnimating ();
			GetComponent<Downsample2AnimationController> ().resetAnimation ();
			GameObject[] downStrideMatrices = GameObject.FindGameObjectsWithTag ("downStrideMatrix");
			for (int i = 0; i < downStrideMatrices.Length; i++) {
				Destroy (downStrideMatrices [i]);
			}

			GameObject[] smallStrideMatrices = GameObject.FindGameObjectsWithTag ("smallStrideMatrix");
			for (int i = 0; i < smallStrideMatrices.Length; i++) {
				smallStrideMatrices [i].GetComponent<StrideMatrixController> ().attachedMatrices = smallStrideMatrices;
				smallStrideMatrices [i].GetComponent<StrideMatrixController> ().canDrag = true;
			}

			downsamplePlane.SetActive (false);
			layers [3].SetActive (false);
			layers [4].SetActive (true);
			layers [5].SetActive (true);

			layers [4].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [4].transform.localPosition = new Vector3 (-0.6f, 0.1f, -0.5f);

			layers [5].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [5].transform.localPosition = new Vector3 (0.6f, 0f, -0.5f);

			lines1.SetActive (true);

			GetComponent<Hidden1AnimationController> ().startAnimating ();
				
		} else if (gameState == GameState.Hidden2) {
			GetComponent<Hidden1AnimationController> ().stopAnimating ();
			layers [4].SetActive (false);
			layers [5].SetActive (true);
			layers [6].SetActive (true);

			layers [5].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [5].transform.localPosition = new Vector3 (-0.6f, 0.1f, -0.5f);

			layers [6].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [6].transform.localPosition = new Vector3 (0.6f, 0f, -0.5f);

			GameObject[] smallStrideMatrices = GameObject.FindGameObjectsWithTag ("smallStrideMatrix");
			for (int i = 0; i < smallStrideMatrices.Length; i++) {
				Destroy (smallStrideMatrices [i]);
			}

			lines1.SetActive (false);
			lines2.SetActive (true);

			GetComponent<Hidden2AnimationController> ().startAnimating ();

		} else if (gameState == GameState.Final) {

			GetComponent<Hidden2AnimationController> ().stopAnimating ();
			layers [5].SetActive (false);
			layers [6].SetActive (true);
			layers [7].SetActive (true);

			layers [6].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [6].transform.localPosition = new Vector3 (-0.6f, 0.1f, -0.5f);

			layers [7].transform.localRotation = Quaternion.Euler (0, -90, 0);
			layers [7].transform.localPosition = new Vector3 (0.6f, 0f, -0.5f);

			layers [7].transform.localScale = new Vector3 (6f, 6f, 6f);

			int greatestIndex = 0;
			for (int i = 0; i < 10; i++) {
				Transform cube = layers [7].transform.GetChild (i);
				GameObject label = Instantiate (FinalValueLabel, cube.position, cube.rotation) as GameObject;
				label.name = "FinalValueLabel";
				label.transform.parent = cube;
				label.transform.localPosition = new Vector3 (0f, 0f, 0.52f);
				label.transform.localScale = new Vector3 (0.0045f, 0.0045f, 0.0045f);
				label.transform.localRotation = Quaternion.Euler (0, 180, 0);
				label.GetComponent<TextMesh> ().text = i.ToString ();

				float currentHighestValue = layers [7].transform.GetChild (greatestIndex).gameObject.GetComponent<CubeController> ().value;
				if (cube.gameObject.GetComponent<CubeController> ().value > currentHighestValue) {
					greatestIndex = i;
				}
			}

			animateGreatestCube = layers [7].transform.GetChild (greatestIndex).gameObject.GetComponent<CubeController> ().animateUpAndDown ();
			StartCoroutine (animateGreatestCube);

			lines2.SetActive (false);
		} else if (gameState == GameState.Full) {
			StopCoroutine (animateGreatestCube);
			for (int i = 0; i < 10; i++) {
				if (layers [7].transform.GetChild (i).GetComponent<CubeController> ().isAnimating) {
					layers [7].transform.GetChild (i).GetComponent<CubeController> ().isAnimating = false;
					Vector3 position = layers [7].transform.GetChild (i).GetComponent<CubeController> ().animationStartPosition;
					layers [7].transform.GetChild (i).position = position;
				}
			}

			drawer.SetActive (true);

			layers [0].SetActive (true);
			layers [0].transform.localPosition = Vector3.zero;
			layers [0].transform.localRotation = Quaternion.Euler (0, 180, 0);
			layers [1].SetActive (true);

			layers [1].transform.localPosition = new Vector3(-0.1f, 0, 0.7f);
			layers [1].transform.localRotation = Quaternion.Euler (0, 45, 90);
			for (int i = 0; i < 6; i++) {
				layers[1].transform.GetChild(i).transform.localRotation = Quaternion.Euler (0, 0, -90);
				layers [1].transform.GetChild (i).transform.localPosition = new Vector3 (1.33f - 0.64f*i, -0.64f*i, 0);
			}

			layers [2].SetActive (true);
			layers [2].transform.localPosition = new Vector3(1.3f, 0, 0.2f);
			layers [2].transform.localRotation = Quaternion.Euler (0, 90, 90);
			for (int i = 0; i < 6; i++) {
				layers[2].transform.GetChild(i).transform.localRotation = Quaternion.Euler (0, 0, -90);
				layers [2].transform.GetChild (i).transform.localPosition = new Vector3 (1.34f - 0.64f*i, -0.64f*i, 0);
			}

			layers [3].SetActive (true);
			layers [3].transform.localPosition = new Vector3(2.3f, 0, -0.9f);
			layers [3].transform.localRotation = Quaternion.Euler (0, 135, 90);
			for (int i = 0; i < 16; i++) {
				layers[3].transform.GetChild(i).transform.localRotation = Quaternion.Euler (0, 0, -90);
				layers [3].transform.GetChild (i).transform.localPosition = new Vector3 (2.01f - 0.28f*i, -0.28f*i, 0);
			}

			layers [4].SetActive (true);
			layers [4].transform.localPosition = new Vector3(1.9f, 0, -2.7f);
			layers [4].transform.localRotation = Quaternion.Euler (0, 180, 90);
			for (int i = 0; i < 16; i++) {
				layers[4].transform.GetChild(i).transform.localRotation = Quaternion.Euler (0, 0, -90);
				layers [4].transform.GetChild (i).transform.localPosition = new Vector3 (2.06f - 0.28f*i, -0.28f*i, 0);
			}

			layers [5].SetActive (true);
			layers [5].transform.localPosition = new Vector3(-1.2f, 0, -2.3f);
			layers [5].transform.localRotation = Quaternion.Euler (0, 235, 90);

			layers [6].SetActive (true);
			layers [6].transform.localPosition = new Vector3(-1.5f, 0, -1.3f);
			layers [6].transform.localRotation = Quaternion.Euler (0, 270, 90);

			layers [7].SetActive (true);
			layers [7].transform.localPosition = new Vector3(-1.0f, 0, -0.4f);
			layers [7].transform.localRotation = Quaternion.Euler (0, 315, 90);
			for (int i = 0; i < 10; i++) {
				layers[7].transform.GetChild(i).localRotation = Quaternion.Euler(180, 0, -90);
			}
		}
	}

	//going to comment out the innards of this since it's incomplete...
	public void previousState() {
//		if (gameState != GameState.Drawing) {
//			gameState--;
//		}
//		if (gameState == GameState.Drawing) {
//			drawer.SetActive (true);
//			layers [1].SetActive (false);
//			layers [0].transform.localRotation = Quaternion.Euler (0, 0, 180);
//			layers [0].transform.localPosition = new Vector3 (0.0f, -650.0f, 0.0f);
//			layers [0].SetActive (false);
//		} else if (gameState == GameState.Input) {
//			//set all children of the cubes of input to be inactive
//			layers[0].SetActive(true);
//			layers[1].SetActive(true);
//			layers [0].transform.localRotation = Quaternion.Euler (0, 0, 90);
//			layers [0].transform.localPosition = new Vector3 (-0.01f, -649.8f, 0.0f);
//			layers [1].transform.localRotation = Quaternion.Euler (0, 0, 270);
//			layers [1].transform.localPosition = new Vector3 (0f, -649.8f, 0f);
//			layers [2].SetActive (false);
//		} 
	}

	private IEnumerator playCurrentAudioClip() {
		yield return new WaitForSeconds (2);
		GetComponent<AudioSource> ().clip = audioClips [audioIndex];
		GetComponent<AudioSource> ().Play ();
		int playingAudioIndex = audioIndex;
		yield return new WaitForSeconds (audioClips [audioIndex].length + 15);
		if (playingAudioIndex == audioIndex) {
			if (audioIndex != 0 && audioIndex != 9) {
				GetComponent<AudioSource> ().clip = thumbsUpReminder;
				GetComponent<AudioSource> ().Play ();
			}
		}
	}

	public void clearInputValueLabels() {
		int numChildren = 1024;
		for (int i = 0; i < numChildren; i++) {
			if (layers [0].transform.GetChild (i).childCount > 0) {
				Destroy (layers [0].transform.GetChild (i).GetChild (0).gameObject);
			}
		}
	}
}
