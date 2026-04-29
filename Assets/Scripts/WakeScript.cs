using System.Collections;
using UnityEngine;

public class WakeScript : MonoBehaviour
{
	public GameObject PlayerWakeAnimation;

	public GameObject playerCameraOn;

	public GameObject sub0;

	public GameObject sub1;

	public GameObject sub2;

	public GameObject tutor;

	private IEnumerator Sub()
	{
		sub0.SetActive(value: true);
		yield return new WaitForSeconds(2f);
		sub0.SetActive(value: false);
		sub1.SetActive(value: true);
		yield return new WaitForSeconds(2f);
		sub1.SetActive(value: false);
		sub2.SetActive(value: true);
		yield return new WaitForSeconds(2f);
		sub2.SetActive(value: false);
		tutor.SetActive(value: true);
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	private IEnumerator DisableAnim()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		yield return new WaitForSeconds(2f);
		PlayerWakeAnimation.GetComponent<Animator>().enabled = false;
		playerCameraOn.GetComponent<PlayerCameraRotation>().enabled = true;
		StartCoroutine(Sub());
	}

	private void Start()
	{
		StartCoroutine(DisableAnim());
	}
}
