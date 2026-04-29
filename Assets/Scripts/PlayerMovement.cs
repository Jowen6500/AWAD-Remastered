using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController player;

	public Transform groundCheck;

	public LayerMask groundMask;

	public float gravity = -100f;

	public float groundDistance = 0.5f;

	public bool isSprinting;

	public float walkSpeed = 7.5f;

	public float sprintingSpeed = 10f;

	public float currentSpeed;

	public float maxStamina = 100f;

	public float consumeStamina = 25f;

	public float generateStamina = 15f;

	public float currentStamina = 100f;

	private Vector3 velocity;

	private bool isGrounded;

	private void FixedUpdate()
	{
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
		if (isGrounded && velocity.y < 0f)
		{
			velocity.y = -2f;
		}
		float axis = Input.GetAxis("Horizontal");
		float axis2 = Input.GetAxis("Vertical");
		Vector3 vector = base.transform.right * axis + base.transform.forward * axis2;
		player.Move(vector * currentSpeed * Time.deltaTime);
		if (Input.GetButton("Sprint"))
		{
			isSprinting = true;
		}
		else
		{
			isSprinting = false;
		}
		if (isSprinting)
		{
			currentStamina -= consumeStamina * Time.deltaTime;
			if (currentStamina < 0f)
			{
				currentStamina = 0f;
				isSprinting = false;
			}
			currentSpeed = sprintingSpeed;
		}
		if (!isSprinting)
		{
			currentStamina += generateStamina * Time.deltaTime;
			if (currentStamina > maxStamina)
			{
				currentStamina = maxStamina;
			}
			currentSpeed = walkSpeed;
		}
		velocity.y += gravity * Time.deltaTime;
		player.Move(velocity * Time.deltaTime);
	}
}
