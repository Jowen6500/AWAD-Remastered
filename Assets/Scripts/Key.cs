using UnityEngine;

public class Key : MonoBehaviour
{
	public Door keyToThisDoor;

	private AudioSource Source;

	public AudioClip Sound;

	private string doorName;

	private void Start()
	{
		Source = GetComponent<AudioSource>();
		doorName = keyToThisDoor.name;
	}

	private void OnCollisionEnter(Collision collisionInfo)
	{
		if (collisionInfo.collider.name == doorName)
		{
			Debug.Log("Key Hit! " + collisionInfo.collider.name);
			Object.Destroy(base.gameObject);
		}
		else
		{
			Source.PlayOneShot(Sound);
		}
	}
}
