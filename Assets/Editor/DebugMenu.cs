using UnityEngine;
using UnityEditor;

public static class DebugMenu
{
	[MenuItem("Debug/Print Global Position")]
	public static void PrintGlobalPosition()
	{
		if (Selection.activeGameObject != null)
		{
			Debug.Log(Selection.activeGameObject.name + " is at " + Selection.activeGameObject.transform.position);
			Debug.Log(Selection.activeGameObject.name + "'s rotation is " + Selection.activeGameObject.transform.rotation.eulerAngles);
		}
	}
}