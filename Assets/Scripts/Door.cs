using UnityEngine;

public class Door : MonoBehaviour
{
	private bool openComplete;

	private string keyName;

	public GameObject key;

	public bool triggered;

	public bool open;

	public float openAngle = 100f;

	public float closedAngle;

	public float smoothSpeed = 2f;

	private AudioSource Source;

	public AudioClip openingSound;

	public AudioClip lockedDoorSound;

	public AudioClip unlockedSound;

	public bool isLocked;

	private void Start()
	{
		Source = GetComponent<AudioSource>();
		keyName = key.name;
		Debug.Log(key.name);
	}

	private void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.name == keyName)
		{
			Debug.Log("Door Hit! " + collisionInfo.collider.name);
			isLocked = false;
			Source.PlayOneShot(unlockedSound);
		}
	}

	public void ChangeDoorState()
	{
		if (!isLocked)
		{
			open = !open;
			Source.PlayOneShot(openingSound);
		}
		else
		{
			Source.PlayOneShot(lockedDoorSound);
		}
	}

	private void Update()
	{
		if (open)
		{
			Quaternion b = Quaternion.Euler(0f, openAngle, 0f);
			base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, b, smoothSpeed * Time.deltaTime);
		}
		else
		{
			Quaternion b2 = Quaternion.Euler(0f, closedAngle, 0f);
			base.transform.localRotation = Quaternion.Slerp(base.transform.localRotation, b2, smoothSpeed * Time.deltaTime);
		}
		if (triggered)
		{
			ChangeDoorState();
			triggered = false;
		}
	}
}
