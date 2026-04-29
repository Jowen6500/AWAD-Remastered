using UnityEngine;

public class TriggerDamage : MonoBehaviour
{
	public float damageAmount = 25f;

	private void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
		{
			col.GetComponent<RegenerativeHealthPointSystem>().Damage(damageAmount);
			Debug.Log("Is Taking Damage!");
		}
	}
}
