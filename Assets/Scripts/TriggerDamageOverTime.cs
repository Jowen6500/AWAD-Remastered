using UnityEngine;

public class TriggerDamageOverTime : MonoBehaviour
{
	public float damageAmount = 25f;

	private void OnTriggerStay(Collider col)
	{
		if (col.tag == "Player")
		{
			col.GetComponent<RegenerativeHealthPointSystem>().Damage(damageAmount * Time.deltaTime);
		}
	}
}
