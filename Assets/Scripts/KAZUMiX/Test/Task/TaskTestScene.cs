using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using KAZUMiX.Task;

namespace KAZUMiX.Test
{
	/// <summary>
	/// TaskSystem 動作テスト用
	/// </summary>
	public class TaskTestScene : MonoBehaviour
	{
		[SerializeField]
		private GameObject prefabTestSpriteTask;

		[SerializeField]
		private Transform canvasTrans;

		private TaskSystem taskSystem;

		// Use this for initialization
		void Start ()
		{
			taskSystem = new TaskSystem ();
		}
	
		// Update is called once per frame
		void Update ()
		{
			taskSystem.Run ();
		}

		private int counter = 0;

		public void OnClick ()
		{
			TestTask testTask = new TestTask ((counter++).ToString ());
			taskSystem.AddTask (testTask);
		}

		public void OnClickBg (BaseEventData baseEventData)
		{
			PointerEventData eventData = baseEventData as PointerEventData;
			Vector3 pos = Camera.main.ScreenToWorldPoint (eventData.position);
			Debug.Log (pos);
			pos.z = 0;

			GameObject go = Instantiate (prefabTestSpriteTask) as GameObject;
			go.transform.position = pos;
			TestSpriteTask spriteTask = go.GetComponent<TestSpriteTask> ();
			taskSystem.AddTask (spriteTask);
		}
	}
}