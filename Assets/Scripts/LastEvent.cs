using UnityEngine;

public class LastEvent : MonoBehaviour
{
	public GameObject EndUI;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			EndUI.SetActive(value: true);
			Time.timeScale = 0f;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}
