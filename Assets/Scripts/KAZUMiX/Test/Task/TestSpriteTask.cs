using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KAZUMiX.Task;

namespace KAZUMiX.Test
{
	// 指定時間でフェードアウトするタスク
	public class TestSpriteTask : BaseTaskMonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer spriteRenderer;

		private float duration = 1.0f;

		private float currentTime = 0;

		public override bool ExecuteTask ()
		{
			currentTime += Time.deltaTime;
			if (currentTime >= duration) {
				return false;
			} else {
				Color color = spriteRenderer.color;
				color.a = 1 - currentTime / duration;
				spriteRenderer.color = color;
				return true;
			}
		}
	}
}