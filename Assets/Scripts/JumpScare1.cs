using System.Collections;
using UnityEngine;

public class JumpScare1 : MonoBehaviour
{
	public AudioSource audioSource;

	public AudioClip scareSound;

	public Light turnOffLight;

	public Light turnOnLight;

	public bool triggered;

	public GameObject activateWendigo;

	public BoxCollider TriggerNextEvent;

	private IEnumerator DelayDestroy()
	{
		yield return new WaitForSeconds(1f);
		activateWendigo.gameObject.SetActive(value: false);
	}

	private IEnumerator DelayLight()
	{
		yield return new WaitForSeconds(1f);
		turnOnLight.enabled = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !triggered)
		{
			activateWendigo.gameObject.SetActive(value: true);
			audioSource.PlayOneShot(scareSound);
			turnOffLight.enabled = false;
			StartCoroutine("DelayDestroy");
			StartCoroutine("DelayLight");
			triggered = true;
			TriggerNextEvent.enabled = true;
		}
	}
}
