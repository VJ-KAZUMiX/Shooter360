﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KAZUMiX.Task
{
	/// <summary>
	/// タスクシステム
	/// </summary>
	public class TaskSystem
	{
		/// <summary>
		/// 初期設定用空タスク
		/// </summary>
		public class EmptyTask : BaseTask
		{
		}

		/// <summary>
		/// 最初のタスク
		/// </summary>
		private ITask firstTask = null;

		/// <summary>
		/// 最後のタスク
		/// </summary>
		private ITask lastTask = null;

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public TaskSystem ()
		{
			// タスクチェーン用初期化
			ITask emptyTask = new EmptyTask ();
			emptyTask.prevTask = emptyTask;
			emptyTask.nextTask = emptyTask;
			firstTask = emptyTask;
			lastTask = emptyTask;
		}

		/// <summary>
		/// チェーンの最後にタスクを追加
		/// </summary>
		/// <param name="newTask">New task.</param>
		public void AddTask (ITask newTask)
		{
			newTask.prevTask = lastTask;
			newTask.nextTask = firstTask;
			lastTask.nextTask = newTask;
			lastTask = newTask;
		}

		/// <summary>
		/// タスクチェーン実行
		/// </summary>
		public void Run ()
		{
			ITask task = firstTask.nextTask;
			while (task != firstTask) {
				// タスク実行
				if (task.Execute ()) {
					// タスク継続
					task = task.nextTask;
				} else {
					// タスク終了処理。チェーンから外す
					ITask finishedTask = task;
					task = finishedTask.nextTask;
					finishedTask.prevTask.nextTask = finishedTask.nextTask;
					finishedTask.nextTask.prevTask = finishedTask.prevTask;
					if (lastTask == finishedTask) {
						lastTask = finishedTask.prevTask;
					}
					finishedTask.prevTask = null;
					finishedTask.nextTask = null;
				}
			}
		}
	}
}
