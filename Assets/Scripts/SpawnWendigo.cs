using UnityEngine;

public class SpawnWendigo : MonoBehaviour
{
	public AudioSource scareAudioSource;

	public AudioClip MonsterSound;

	public AudioClip scareSound;

	public Light turnOff1;

	public Light turnOff2;

	public GameObject activateObject;

	public BoxCollider TriggerNextEvent;

	private bool hasPlayedAudio;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !hasPlayedAudio)
		{
			activateObject.gameObject.SetActive(value: true);
			scareAudioSource.PlayOneShot(scareSound);
			turnOff1.enabled = false;
			turnOff2.enabled = false;
			scareAudioSource.loop = true;
			scareAudioSource.clip = MonsterSound;
			scareAudioSource.volume = 1f;
			scareAudioSource.Play();
			hasPlayedAudio = true;
			TriggerNextEvent.enabled = true;
		}
	}
}
