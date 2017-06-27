using UnityEngine;
using System.Collections;

/// <summary>
/// 単一のシーンでのみシングルトンとして振る舞うオブジェクト用。
///  アクティブになっていない状態だと取得できません。
/// </summary>
public class SceneSingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
	// private.
	private static T _instance = null;

	public virtual void Awake ()
	{
		if (_instance != null) {
			Debug.LogWarning (typeof(T).FullName + " Awake 時に _instance が null ではありません。");
		}
		_instance = (T)(object)this;
	}

	public static T Instance {
		get {
			if (_instance == null) {
				_instance = (T)FindObjectOfType (typeof(T));
				if (_instance == null) {
					Debug.LogWarning (typeof(T).FullName + " の _instance が null です。");
				}
			}
			return _instance;
		}
	}

	public virtual void OnDestroy ()
	{
		Debug.Log (typeof(T).FullName + ".OnDestroy()");
		_instance = null;
	}
}
