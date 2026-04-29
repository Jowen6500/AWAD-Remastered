using UnityEngine;

public class tes : MonoBehaviour
{
	public Transform player;

	public Transform head;

	private Animator anim;

	private string state = "patrol";

	public GameObject[] waypoints;

	private int currentWP;

	public float rotSpeed = 0.2f;

	public float speed = 1.5f;

	public float attackRange = 2f;

	private float accuracyWP = 5f;

	public float sight = 2f;

	private AudioSource source;

	private void Start()
	{
		anim = GetComponent<Animator>();
	}

	private void Update()
	{
		Vector3 vector = player.position - base.transform.position;
		vector.y = 0f;
		float num = Vector3.Angle(vector, head.up);
		if (state == "patrol" && waypoints.Length != 0)
		{
			anim.SetBool("isIdle", value: false);
			anim.SetBool("isWalking", value: true);
			if (Vector3.Distance(waypoints[currentWP].transform.position, base.transform.position) < accuracyWP)
			{
				currentWP++;
				if (currentWP >= waypoints.Length)
				{
					currentWP = 0;
				}
			}
			vector = waypoints[currentWP].transform.position - base.transform.position;
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Quaternion.LookRotation(vector), rotSpeed * Time.deltaTime);
			base.transform.Translate(0f, 0f, Time.deltaTime * speed);
		}
		if (Vector3.Distance(player.position, base.transform.position) < sight && (num < 30f || state == "pursuing"))
		{
			state = "pursuing";
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Quaternion.LookRotation(vector), Time.deltaTime * speed);
			if (vector.magnitude > attackRange)
			{
				base.transform.Translate(0f, 0f, Time.deltaTime * speed);
				anim.SetBool("isWalking", value: true);
				anim.SetBool("isAttacking", value: false);
			}
			else
			{
				anim.SetBool("isAttacking", value: true);
				anim.SetBool("isWalking", value: false);
			}
		}
		else
		{
			anim.SetBool("isWalking", value: false);
			anim.SetBool("isAttacking", value: false);
			state = "patrol";
		}
	}
}
