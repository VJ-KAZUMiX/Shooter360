using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUiManager : MonoBehaviour
{
	public Delegate.VoidDelegate FirePressEvent;

	public Delegate.VoidDelegate FireReleaseEvent;

	public void OnFirePress ()
	{
		if (FirePressEvent != null) {
			FirePressEvent ();
		}
	}

	public void OnFireRelease ()
	{
		if (FireReleaseEvent != null) {
			FireReleaseEvent ();
		}
	}
}
