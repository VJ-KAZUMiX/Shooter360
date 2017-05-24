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
}
