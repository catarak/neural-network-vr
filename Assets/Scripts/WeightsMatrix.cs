using UnityEngine;
using System;

[Serializable]
public class WeightsMatrix{
	public WeightsArray[] weights;

	public static WeightsMatrix CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<WeightsMatrix>(jsonString);
	}
}
