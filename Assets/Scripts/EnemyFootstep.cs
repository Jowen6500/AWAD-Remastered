using UnityEngine;

public class EnemyFootstep : MonoBehaviour
{
	public AudioClip stepSound;

	private AudioSource source;

	private void OnTriggerEnter(Collider col)
	{
		Debug.Log("is stepping");
		source.PlayOneShot(stepSound);
	}

	private void Start()
	{
		source = GetComponent<AudioSource>();
	}
}
