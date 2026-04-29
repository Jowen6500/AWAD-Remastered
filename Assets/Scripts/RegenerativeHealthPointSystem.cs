using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RegenerativeHealthPointSystem : MonoBehaviour
{
	public CharacterController player;

	public Rigidbody playerRagdoll;

	public CapsuleCollider playerCapsuleCollider;

	public GameObject playerScriptMoveOff;

	public GameObject playerCameraOff;

	public Color damageFlashColor;

	public Image damageImage;

	public Image healthImage;

	public GameObject deathTxt;

	public GameObject retryBttn;

	public GameObject quitBttn;

	public bool isTakingDamage;

	public bool isDead;

	public bool playDeathScreen;

	public float currentHP = 100f;

	public float generateHealth = 10f;

	public float maxHP = 100f;

	public float currentDamage;

	public float damageFlashSpeed = 3f;

	public AudioSource source;

	public AudioClip deathSound;

	public AudioClip dmgSound;

	private float r;

	private float g;

	private float b;

	private float a;

	private void DisableRagdoll()
	{
		playerRagdoll.useGravity = false;
		playerRagdoll.isKinematic = true;
		playerRagdoll.detectCollisions = false;
	}

	private void EnableRagdoll()
	{
		playerScriptMoveOff.GetComponent<PlayerMovement>().enabled = false;
		playerRagdoll.useGravity = true;
		playerRagdoll.isKinematic = false;
		playerRagdoll.detectCollisions = true;
	}

	public void Damage(float damage)
	{
		currentDamage = damage;
		currentHP -= currentDamage;
		if (currentHP <= 0f)
		{
			currentHP = 0f;
			EnableRagdoll();
			Dead();
			if (!isDead)
			{
				StartCoroutine(PlayAudio());
			}
			isTakingDamage = false;
		}
		else
		{
			isTakingDamage = true;
		}
	}

	private void DamageFlash()
	{
		if (isTakingDamage)
		{
			source.PlayOneShot(dmgSound);
			damageImage.color = damageFlashColor;
		}
		else
		{
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, damageFlashSpeed * Time.deltaTime);
		}
		isTakingDamage = false;
	}

	private void Dead()
	{
		player.enabled = false;
		playerCapsuleCollider.enabled = true;
		playerRagdoll.AddForce(base.transform.right * -2f);
	}

	private void Heal()
	{
		currentHP += generateHealth * Time.deltaTime;
		if (currentHP >= maxHP)
		{
			currentHP = maxHP;
		}
	}

	private void AdjustHealthImage()
	{
		r = 170f;
		a = maxHP / maxHP - currentHP / maxHP;
		a = Mathf.Clamp(a, 0f, 1f);
		Color color = new Color(r, g, b, a);
		healthImage.color = color;
	}

	private IEnumerator PlayAudio()
	{
		Debug.Log("You're dead..");
		isDead = true;
		source.PlayOneShot(deathSound);
		yield return new WaitForSeconds(deathSound.length);
		source.loop = true;
		source.Play();
		playDeathScreen = true;
	}

	private IEnumerator DeathScreen()
	{
		deathTxt.SetActive(value: true);
		yield return new WaitForSeconds(1f);
		retryBttn.SetActive(value: true);
		quitBttn.SetActive(value: true);
	}

	private void start()
	{
		DisableRagdoll();
		player.GetComponent<CharacterController>();
		playerRagdoll.GetComponent<Rigidbody>();
		playerCapsuleCollider.GetComponent<CapsuleCollider>();
		source = GetComponent<AudioSource>();
		r = healthImage.color.r;
		g = healthImage.color.g;
		b = healthImage.color.b;
		a = healthImage.color.a;
	}

	private void FixedUpdate()
	{
		DamageFlash();
		AdjustHealthImage();
		if (currentHP > 0f)
		{
			Heal();
		}
		if (playDeathScreen)
		{
			playerCameraOff.GetComponent<PlayerCameraRotation>().enabled = false;
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			StartCoroutine(DeathScreen());
		}
	}
}
