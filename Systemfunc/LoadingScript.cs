using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
	//　非同期動作で使用するAsyncOperation
	private AsyncOperation async;
	//　ロード中に表示するUI画面
	[SerializeField]
	private GameObject loadUI;
	
	[SerializeField]
	private Slider slider;

	public void NextScene()
	{
		//　ロード画面UIをアクティブ
		loadUI.SetActive(true);

		//　コルーチン開始
		StartCoroutine("LoadData");
	}

	IEnumerator LoadData()
	{
		// シーン読み込み
		async = SceneManager.LoadSceneAsync("gameover");

		//　読み込みが終わるまで進捗状況をスライダーの値に反映
		while (!async.isDone)
		{
			var progressVal = Mathf.Clamp01(async.progress / 0.9f);
			slider.value = progressVal;
			yield return null;
		}
	}
}
