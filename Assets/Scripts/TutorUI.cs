using UnityEngine;

public class TutorUI : MonoBehaviour
{
	public GameObject tutorialUI;

	public GameObject tutorialUI2;

	public CharacterController player;

	public void Continue()
	{
		tutorialUI.SetActive(value: false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		player.enabled = true;
	}

	public void tutor2()
	{
		tutorialUI2.SetActive(value: false);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		player.enabled = true;
	}
}
