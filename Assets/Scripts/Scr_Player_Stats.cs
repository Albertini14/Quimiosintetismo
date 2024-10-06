using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scr_Player_Stats : Scr_Character_Stats
{

	[SerializeField] TextMeshProUGUI txt_health;
	[SerializeField] TextMeshProUGUI txt_progress;

	[SerializeField] float Evolve_Goal = 3;

	public Stat Evolution;
	[SerializeField] int Level;

	void Start(){
		UpdateUI();
		txt_progress.text = Evolution.GetValue().ToString("n0") + " / " + Evolve_Goal.ToString("n0");
	}

	void Update(){
		currentHealth = Mathf.Clamp(currentHealth + (Regen_Base.GetValue() * Regen_Mult.GetValue() * Time.deltaTime), -100, Health_Base.GetValue() * Health_Mult.GetValue());
		UpdateUI();

	}


	public void OnSkillTreeChanged(Upgrade newUpgrade)
	{
		// Debug.Log("delageted");
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
			Damage_Base.AddModifier(newUpgrade.Damage_Base_mod);
			Damage_Mult.AddModifier(newUpgrade.Damage_Mult_mod);
		}

		UpdateUI();

	}

	// Duplicate
	// grapple
	// Dash
	// Attack



	public void OnSkillGained(Skill newSkill){
		switch (newSkill.name){
			case "Replicate":
				if(newSkill.min_level <= Level && Level <= newSkill.max_level){
					
				}
				break;
			case "Grapple":
			
				break;
			case "Dash":
			
				break;
			case "Attack":
			
				break;
		}
	}


	public void GainXp(float xp){
		//gain xp, on reaching max, pass to new level
		Evolution.AddModifier(xp);
		txt_progress.text = Evolution.GetValue().ToString("n0") + " / " + Evolve_Goal.ToString("n0");
		// check if full == win
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
		// 	if there is a duplicate 
		//		change to duplicate
		// 	else 
		// 		Flag Game over
		Debug.Log("died");
		
		//base.Die();
		
	}

	void UpdateUI(){
		// Debug.Log("ui updated");
		txt_health.text = currentHealth.ToString("n0") + " / " + (Health_Base.GetValue() * Health_Mult.GetValue()).ToString("n0");
		// Debug.Log(Speed_Base.GetValue());
	}

}
