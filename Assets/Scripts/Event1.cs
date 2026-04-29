using UnityEngine;

public class Event1 : MonoBehaviour
{
	public CharacterController player;

	public GameObject tutorHUD;

	public bool triggered;

	private void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag("Player") && !triggered)
		{
			player.enabled = false;
			tutorHUD.SetActive(value: true);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			triggered = true;
		}
	}
}
