using UnityEngine;

public class SolvingPaperD : MonoBehaviour
{
	public bool triggered;

	public BoxCollider TriggerNextEvent;

	public GameObject ActivateKey;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !triggered)
		{
			ActivateKey.gameObject.SetActive(value: true);
			triggered = true;
			TriggerNextEvent.enabled = true;
		}
	}
}
