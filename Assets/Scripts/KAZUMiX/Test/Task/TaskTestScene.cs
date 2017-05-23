using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KAZUMiX.Task;

namespace KAZUMiX.Test
{
	/// <summary>
	/// TaskSystem 動作テスト用
	/// </summary>
	public class TaskTestScene : MonoBehaviour
	{
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
	}
}