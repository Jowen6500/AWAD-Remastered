using UnityEngine;

public class PickUpFlashlight : MonoBehaviour
{
	public AudioClip pickSound;

	public GameObject flashlightOnCamera;

	private AudioSource source;

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}

	public void PickupFlashlight()
	{
		source.PlayOneShot(pickSound);
		flashlightOnCamera.SetActive(value: true);
		Object.Destroy(base.gameObject, pickSound.length);
	}
}
