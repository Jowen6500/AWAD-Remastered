using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenuS : MonoBehaviour
{
	public static bool GameIsPaused;

	public GameObject pauseMenuUI;

	public void Resume()
	{
		pauseMenuUI.SetActive(value: false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	private void Paused()
	{
		pauseMenuUI.SetActive(value: true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	public void LoadMenu()
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene("Test2");
	}

	public void QuitGame()
	{
		Application.Quit();
		Debug.Log("Quiting..");
	}

	private void Update()
	{
		if (Input.GetButtonDown("Cancel"))
		{
			if (GameIsPaused)
			{
				Resume();
			}
			else
			{
				Paused();
			}
		}
	}
}
