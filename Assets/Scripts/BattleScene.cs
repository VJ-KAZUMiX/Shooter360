using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KAZUMiX.Task;

public class BattleScene : MonoBehaviour
{
	[SerializeField]
	private BattleUiManager battleUiManager;

	[SerializeField]
	private GameObject prefabPlayer;

	private TaskSystem taskSystem;

	// Use this for initialization
	void Start ()
	{
		taskSystem = new TaskSystem ();
		createPlayer ();
	}

	void Update ()
	{
		taskSystem.Run ();
	}

	private void createPlayer ()
	{
		GameObject go = Instantiate (prefabPlayer) as GameObject;
		PlayerCtrl playerCtrl = go.GetComponent<PlayerCtrl> ();
		playerCtrl.Init (taskSystem, battleUiManager);
		taskSystem.AddTask (playerCtrl);

		// カメラ設定
		Transform cameraTrans = Camera.main.transform;
		Vector3 cameraPos = cameraTrans.position;
		cameraTrans.SetParent (playerCtrl.transform);
		cameraPos.y = 1;
		cameraTrans.position = cameraPos;
	}
}
