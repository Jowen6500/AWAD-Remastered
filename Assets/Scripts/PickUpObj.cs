using UnityEngine;

public class PickUpObj : MonoBehaviour
{
	private Vector3 objectPos;

	private float range;

	public float distance = 1.5f;

	public float throwForce = 600f;

	public bool canHold = true;

	public GameObject item;

	private GameObject tempParent;

	public bool isHolding;

	private AudioSource Source;

	public AudioClip Sound;

	private void Start()
	{
		Source = GetComponent<AudioSource>();
		tempParent = GameObject.Find("Guide");
	}

	private void Update()
	{
		range = Vector3.Distance(item.transform.position, tempParent.transform.position);
		if (range >= distance)
		{
			isHolding = false;
		}
		if (isHolding)
		{
			item.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
			item.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
			item.transform.SetParent(tempParent.transform);
			if (Input.GetButtonDown("Fire2"))
			{
				item.GetComponent<Rigidbody>().AddForce(tempParent.transform.forward * throwForce);
				isHolding = false;
			}
		}
		else
		{
			objectPos = item.transform.position;
			item.transform.SetParent(null);
			item.GetComponent<Rigidbody>().useGravity = true;
			item.transform.position = objectPos;
		}
	}

	private void OnMouseDown()
	{
		if (range <= distance)
		{
			isHolding = true;
			item.GetComponent<Rigidbody>().useGravity = false;
			item.GetComponent<Rigidbody>().detectCollisions = true;
		}
		isHolding = true;
		item.GetComponent<Rigidbody>().useGravity = false;
		item.GetComponent<Rigidbody>().detectCollisions = true;
	}

	private void OnMouseUp()
	{
		isHolding = false;
	}

	private void OnCollisionEnter(Collision col)
	{
		Source.PlayOneShot(Sound);
	}
}
