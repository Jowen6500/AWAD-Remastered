using UnityEngine;

public class AllLightsOff : MonoBehaviour
{
	public GameObject allLights;

	public GameObject AIenable;

	public bool triggered;

	private AudioSource Source;

	public AudioClip blackOutSound;

	private void Start()
	{
		Source = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !triggered)
		{
			allLights.gameObject.SetActive(value: false);
			Source.PlayOneShot(blackOutSound);
			triggered = true;
			AIenable.SetActive(value: true);
		}
	}
}
