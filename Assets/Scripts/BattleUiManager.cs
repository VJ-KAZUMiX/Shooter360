using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleUiManager : MonoBehaviour
{
	[SerializeField]
	private Camera uiCamera;

	public Delegate.VoidDelegate FirePressEvent;

	public Delegate.VoidDelegate FireReleaseEvent;

	public delegate void Vector3Delegate (Vector3 value);

	public Vector3Delegate BgBeginDragEvent;

	public Vector3Delegate BgEndDragEvent;

	public Vector3Delegate BgDragEvent;

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

	public void OnBeginDrag (BaseEventData baseEventData)
	{
		PointerEventData pointerEventData = baseEventData as PointerEventData;
		Vector3 pos = uiCamera.ScreenToWorldPoint (pointerEventData.position);
		pos.z = 0;
		if (BgBeginDragEvent != null) {
			BgBeginDragEvent (pos);
		}
	}

	public void OnEndDrag (BaseEventData baseEventData)
	{
		PointerEventData pointerEventData = baseEventData as PointerEventData;
		Vector3 pos = uiCamera.ScreenToWorldPoint (pointerEventData.position);
		pos.z = 0;
		if (BgEndDragEvent != null) {
			BgEndDragEvent (pos);
		}
	}

	public void OnDrag (BaseEventData baseEventData)
	{
		PointerEventData pointerEventData = baseEventData as PointerEventData;
		Vector3 pos = uiCamera.ScreenToWorldPoint (pointerEventData.position);
		pos.z = 0;
		if (BgDragEvent != null) {
			BgDragEvent (pos);
		}
	}
}
