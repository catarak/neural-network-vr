using UnityEngine;
using System;

[Serializable]
public class Nodes {
	public Node[] nodes;

	public static Nodes CreateFromJSON(string jsonString)
	{
		return JsonUtility.FromJson<Nodes>(jsonString);
	}


}
