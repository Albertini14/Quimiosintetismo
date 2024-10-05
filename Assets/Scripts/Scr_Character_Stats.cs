using UnityEngine;


public class Scr_Character_Stats : MonoBehaviour
{

	public float currentHealth;

	public Stat Health_Base;
	public Stat Health_Mult;
	public Stat Speed_Base;
	public Stat Speed_Mult;
	public Stat Resilience;

	
	void Awake()
	{
		currentHealth = Health_Base.GetValue() * Health_Mult.GetValue();
	}

	public void TakeDamage(float damage)
	{
		damage -= Resilience.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);

		currentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + " damage.");

		if (currentHealth <= 0)
		{
			Die();
		}
	}

	public virtual void Die()
	{
		Debug.Log(transform.name + " died.");
	}
}



