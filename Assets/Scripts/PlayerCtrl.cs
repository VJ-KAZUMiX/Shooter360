using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using KAZUMiX.Task;

public class PlayerCtrl : BaseTaskMonoBehaviour
{
	[SerializeField]
	private GameObject prefabPlayerBullet;

	/// <summary>
	/// 弾丸用タスクシステム
	/// </summary>
	private TaskSystem bulletTaskSystem;

	public void Init (TaskSystem bulletTaskSystem, BattleUiManager battleUiManager)
	{
		this.bulletTaskSystem = bulletTaskSystem;

		battleUiManager.FirePressEvent += OnTriggerPress;
		battleUiManager.FireReleaseEvent += OnTriggerRelease;

		battleUiManager.BgBeginDragEvent += OnBeginDrag;
		battleUiManager.BgEndDragEvent += OnEndDrag;
		battleUiManager.BgDragEvent += OnDrag;
	}

	public void OnTriggerPress ()
	{
		Fire ();
	}

	public void OnTriggerRelease ()
	{

	}

	private void Fire ()
	{
		GameObject go = Instantiate (prefabPlayerBullet) as GameObject;
		BulletCtrl bulletCtrl = go.GetComponent<BulletCtrl> ();
		bulletCtrl.Init ();
		bulletTaskSystem.AddTask (bulletCtrl);
	}

	private float prevAngle;

	private void OnBeginDrag (Vector3 pos)
	{
		prevAngle = Mathf.Atan2 (pos.y - transform.position.y, pos.x - transform.position.x);
	}

	private void OnEndDrag (Vector3 pos)
	{
		// TODO: これいる？
		prevAngle = Mathf.Atan2 (pos.y - transform.position.y, pos.x - transform.position.x);
	}

	private void OnDrag (Vector3 pos)
	{
		float currentAngle = Mathf.Atan2 (pos.y - transform.position.y, pos.x - transform.position.x);
		float deltaAngle = prevAngle - currentAngle;
		Debug.Log (string.Format ("currentAngle: {0}, deltaAngle: {1}, prevAngle {2}", currentAngle, deltaAngle, prevAngle));
		transform.Rotate (new Vector3 (0, 0, deltaAngle * 180 / Mathf.PI));
		prevAngle = currentAngle;
	}
}
