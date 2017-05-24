using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KAZUMiX.Task
{
	/// <summary>
	/// タスクシステム用抽象タスククラス。GameObject 用。
	/// </summary>
	public abstract class BaseTaskMonoBehaviour : MonoBehaviour, ITask
	{
		public ITask prevTask { get; set; }

		public ITask nextTask { get; set; }

		public virtual bool ExecuteTask ()
		{
			return true;
		}

		public virtual void OnFinishTask ()
		{
			Destroy (gameObject);
		}
	}
}