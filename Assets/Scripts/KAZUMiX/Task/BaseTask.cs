using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KAZUMiX.Task
{
	/// <summary>
	/// タスクシステム用抽象タスククラス。GameObject の場合は BaseTaskMonobehaviour を利用すること。
	/// </summary>
	public abstract class BaseTask: ITask
	{
		public ITask prevTask { get; set; }

		public ITask nextTask { get; set; }

		public virtual bool ExecuteTask ()
		{
			return true;
		}

		public virtual void OnFinishTask ()
		{
			return;
		}
	}
}
