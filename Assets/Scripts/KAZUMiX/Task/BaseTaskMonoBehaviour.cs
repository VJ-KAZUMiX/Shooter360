using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KAZUMiX.Task
{
	public class BaseTaskMonoBehaviour : MonoBehaviour, ITask
	{
		public ITask prevTask { get; set; }

		public ITask nextTask { get; set; }

		public virtual bool Execute ()
		{
			return false;
		}
	}
}