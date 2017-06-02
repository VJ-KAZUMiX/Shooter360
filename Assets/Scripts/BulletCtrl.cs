using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KAZUMiX.Task;

public class BulletCtrl : BaseTaskMonoBehaviour
{
	public void Init (Vector2 direction, Quaternion rotation)
	{
		this.direction = direction;
		transform.rotation = rotation;
		speed = 5.0f;
		range = 10.0f;
		movingDistance = 0;
	}

	public override bool ExecuteTask ()
	{
		MoveForward ();
		if (movingDistance >= range) {
			return false;
		} else {
			return true;
		}
	}

	private Vector2 direction;

	private float speed;

	private float range;

	private float movingDistance;

	private void MoveForward ()
	{
		Vector2 pos = transform.localPosition;
		pos += direction * speed * Time.deltaTime;
		movingDistance += speed * Time.deltaTime;
		transform.localPosition = pos;
	}
}
