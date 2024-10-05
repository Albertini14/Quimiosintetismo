using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player_Stats : Scr_Character_Stats
{

	public void OnSkillTreeChanged(Upgrade newUpgrade)
	{
		Debug.Log("delageted");
		// Add new modifiers
		if (newUpgrade != null)
		{
			Resilience.AddModifier(newUpgrade.Resilience_mod);
			Health_Base.AddModifier(newUpgrade.Resilience_mod);
			Health_Mult.AddModifier(newUpgrade.Resilience_mod);
			Speed_Base.AddModifier(newUpgrade.Speed_Base_mod);
			Speed_Mult.AddModifier(newUpgrade.Speed_Mult_mod);
		}


	}

	public override void Die()
	{
		base.Die();
		//kill current character
	}
}
