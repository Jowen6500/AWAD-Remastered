using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingLevel : MonoBehaviour
{
	public GameObject loadingScreen;

	public Slider slider;

	public Text progressText;

	public void LoadLevel(int sceneIndex)
	{
		Time.timeScale = 1f;
		StartCoroutine(LoadAsynchronously(sceneIndex));
	}

	private IEnumerator LoadAsynchronously(int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
		loadingScreen.SetActive(value: true);
		while (!operation.isDone)
		{
			float num = Mathf.Clamp01(operation.progress / 0.9f);
			slider.value = num;
			progressText.text = num * 100f + "%";
			yield return null;
		}
	}
}
