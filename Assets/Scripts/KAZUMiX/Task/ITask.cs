using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KAZUMiX.Task
{
	public interface ITask
	{
		/// <summary>
		/// 前のタスク
		/// </summary>
		ITask prevTask {get; set;}

		/// <summary>
		/// 次のタスク
		/// </summary>
		ITask nextTask {get; set;}

		/// <summary>
		/// 毎フレーム呼び出し
		/// </summary>
		bool Execute ();
	}
}