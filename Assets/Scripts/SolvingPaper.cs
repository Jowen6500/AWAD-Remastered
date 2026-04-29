using UnityEngine;

public class SolvingPaper : MonoBehaviour
{
	public bool triggered;

	public BoxCollider TriggerNextEvent;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && !triggered)
		{
			triggered = true;
			TriggerNextEvent.enabled = true;
		}
	}
}
