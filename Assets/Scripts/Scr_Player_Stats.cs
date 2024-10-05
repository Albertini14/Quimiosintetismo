using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scr_Player_Stats : Scr_Character_Stats
{

	[SerializeField] TextMeshProUGUI txt_health;

	void Start(){
		UpdateUI();
	}

	void Update(){
		currentHealth += (Regen_Base.GetValue() * Regen_Mult.GetValue() * Time.deltaTime);
		UpdateUI();
	}


	public void OnSkillTreeChanged(Upgrade newUpgrade)
	{
		Debug.Log("delageted");
		// Add new modifiers
		if (newUpgrade != null)
		{
			Resilience.AddModifier(newUpgrade.Resilience_mod);
			Health_Base.AddModifier(newUpgrade.Health_Base_mod);
			Health_Mult.AddModifier(newUpgrade.Health_Mult_mod);
			Speed_Base.AddModifier(newUpgrade.Speed_Base_mod);
			Speed_Mult.AddModifier(newUpgrade.Speed_Mult_mod);
			Regen_Base.AddModifier(newUpgrade.Regen_Base_mod);
			Regen_Mult.AddModifier(newUpgrade.Regen_Mult_mod);
		}

		UpdateUI();

	}

	public override void TakeDamage(float damage){
		base.TakeDamage(damage);
		UpdateUI();
		// Change Spriet
		FindObjectOfType<Animator>().SetTrigger("Take_dmg");
		// push enemies
		// invulnerability for 1 second
	}

	public override void Die()
	{
		base.Die();
		//kill current character
	}

	void UpdateUI(){
		Debug.Log("ui updated");
		txt_health.text = currentHealth.ToString("n0") + " / " + (Health_Base.GetValue() * Health_Mult.GetValue()).ToString("n0");
		Debug.Log(Speed_Base.GetValue());
	}



}
