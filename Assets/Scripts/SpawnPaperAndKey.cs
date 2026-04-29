using UnityEngine;

public class SpawnPaperAndKey : MonoBehaviour
{
	public AudioSource audioSource;

	public AudioClip sound;

	public bool triggered;

	public GameObject activatePaper;

	public GameObject activateKey;

	public BoxCollider TriggerNextEvent;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !triggered)
		{
			activatePaper.gameObject.SetActive(value: true);
			activateKey.gameObject.SetActive(value: true);
			audioSource.PlayOneShot(sound);
			triggered = true;
			TriggerNextEvent.enabled = true;
		}
	}
}
