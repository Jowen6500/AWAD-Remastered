using UnityEngine;

public class DespawnWendigo : MonoBehaviour
{
	public GameObject DeactivateObject;

	public Light turnOn1;

	public Light turnOn2;

	private bool Triggered;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			DeactivateObject.gameObject.SetActive(value: false);
			turnOn1.enabled = true;
			turnOn2.enabled = true;
		}
	}
}
