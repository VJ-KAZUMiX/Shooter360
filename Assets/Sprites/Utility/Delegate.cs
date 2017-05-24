using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Delegate
{
	public delegate void VoidDelegate ();

	public delegate void BoolDelegate (bool value);

	public delegate void IntDelegate (int value);

	public delegate void FloatDelegate (float value);

	public delegate void StringDelegate (string value);

	public delegate void ObjectDelegate (GameObject value);
}
