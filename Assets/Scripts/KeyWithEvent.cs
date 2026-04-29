using UnityEngine;

public class KeyWithEvent : MonoBehaviour
{
	public Door myDoor;

	private AudioSource keyAudioSource;

	public AudioSource scareAudioSource;

	public AudioClip MonsterSound;

	public AudioClip scareSound;

	public AudioClip PickKeySound;

	public Light turnOff1;

	public Light turnOff2;

	public GameObject Wendigo;

	public BoxCollider TriggerNext;

	private bool hasPlayedAudio;

	private void Start()
	{
		keyAudioSource = GetComponent<AudioSource>();
	}

	public void UnlockDoor()
	{
		myDoor.isLocked = false;
		keyAudioSource.PlayOneShot(PickKeySound);
		base.gameObject.SetActive(value: false);
		scareAudioSource.PlayOneShot(scareSound);
		turnOff1.enabled = false;
		turnOff2.enabled = false;
		scareAudioSource.loop = true;
		scareAudioSource.clip = MonsterSound;
		scareAudioSource.volume = 1f;
		scareAudioSource.Play();
		Wendigo.SetActive(value: true);
		TriggerNext.enabled = true;
	}
}
