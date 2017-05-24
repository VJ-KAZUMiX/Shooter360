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
		/// <summary>
		/// transform キャッシュ
		/// </summary>
		private Transform _cache_transform;

		/// <summary>
		/// キャッシュ済み transform
		/// </summary>
		/// <value>The transform.</value>
		public new Transform transform { get { return _cache_transform ?? (_cache_transform = gameObject.transform); } }

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