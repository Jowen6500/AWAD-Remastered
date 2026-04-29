using UnityEngine;
using UnityEngine.UI;

public class interact : MonoBehaviour
{
	public string interactButton;

	public float interactDistance = 3f;

	public bool isInteracting;

	public LayerMask interactLayer;

	public Image interactIcon;

	private void Start()
	{
		if (interactIcon != null)
		{
			interactIcon.enabled = false;
		}
	}

	private void Update()
	{
		if (Physics.Raycast(new Ray(base.transform.position, base.transform.forward), out var hitInfo, interactDistance, interactLayer))
		{
			if (isInteracting)
			{
				return;
			}
			if (interactIcon != null)
			{
				interactIcon.enabled = true;
			}
			if (Input.GetButtonDown(interactButton))
			{
				if (hitInfo.collider.CompareTag("Door"))
				{
					hitInfo.collider.GetComponent<Door>().ChangeDoorState();
				}
				else if (hitInfo.collider.CompareTag("Flashlight"))
				{
					hitInfo.collider.GetComponent<PickUpFlashlight>().PickupFlashlight();
				}
			}
		}
		else
		{
			interactIcon.enabled = false;
		}
	}
}
