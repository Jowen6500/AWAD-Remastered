using UnityEngine;

public class Flashlight : MonoBehaviour
{
	private Light flashlight;

	private AudioSource source;

	public AudioClip soundFlashlighton;

	public AudioClip soundFlashlightoff;

	private bool isActive;

	private void Start()
	{
		flashlight = GetComponent<Light>();
		source = GetComponent<AudioSource>();
		isActive = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (!isActive)
			{
				flashlight.enabled = true;
				isActive = true;
				source.PlayOneShot(soundFlashlighton);
			}
			else if (isActive)
			{
				flashlight.enabled = false;
				isActive = false;
				source.PlayOneShot(soundFlashlightoff);
			}
		}
	}
}
