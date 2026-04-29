using UnityEngine;

public class SpawnSomething : MonoBehaviour
{
	public AudioSource audioSource;

	public AudioClip sound;

	public bool triggered;

	public GameObject activateObject;

	public BoxCollider TriggerNextEvent;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !triggered)
		{
			activateObject.gameObject.SetActive(value: true);
			audioSource.PlayOneShot(sound);
			triggered = true;
			TriggerNextEvent.enabled = true;
		}
	}
}
