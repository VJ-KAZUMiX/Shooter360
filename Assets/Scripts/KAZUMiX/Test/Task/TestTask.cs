using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KAZUMiX.Task;

namespace KAZUMiX.Test
{
	/// <summary>
	/// 指定時間経過したら終了するテストタスク
	/// </summary>
	public class TestTask: BaseTask
	{
		public string taskName;

		private float currentTime = 0;

		private float maxTime = 3.0f;

		public override string ToString ()
		{
			return string.Format ("[TestTask] ({0})", taskName);
		}

		public TestTask (string taskName)
		{
			this.taskName = taskName;
		}

		public override bool Execute ()
		{
			currentTime += Time.deltaTime;
			if (currentTime >= maxTime) {
				Debug.Log (this + " 指定時間経過したので終了です");
				return false;
			} else {
				return true;
			}
		}
	}
}