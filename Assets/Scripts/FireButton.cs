using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FireButton : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
	public void OnBeginDrag (PointerEventData pointerEventData)
	{
		ExecuteEvents.ExecuteHierarchy (transform.parent.gameObject, pointerEventData, ExecuteEvents.beginDragHandler);
	}

	public void OnEndDrag (PointerEventData pointerEventData)
	{
		ExecuteEvents.ExecuteHierarchy (transform.parent.gameObject, pointerEventData, ExecuteEvents.endDragHandler);
	}

	public void OnDrag (PointerEventData pointerEventData)
	{
		ExecuteEvents.ExecuteHierarchy (transform.parent.gameObject, pointerEventData, ExecuteEvents.dragHandler);
	}

}
