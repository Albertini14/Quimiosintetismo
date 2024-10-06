using UnityEngine;

/* The base item class. All items should derive from this. */

[CreateAssetMenu(fileName = "New Upgrade", menuName = "SkillTree/Upgrade")]
public class Upgrade : ScriptableObject
{

	new public string name = "New Upgrade";
	public Sprite icon = null;              // Skill icon

	public float Health_Base_mod = 0;
	public float Health_Mult_mod = 1;
	public float Speed_Base_mod = 0;
	public float Speed_Mult_mod = 1;
	public float Resilience_mod = 0;
	public float Regen_Base_mod = 0;
	public float Regen_Mult_mod = 0;
	public float Damage_Base_mod = 0;
	public float Damage_Mult_mod = 1; 

	public Scr_Player_Stats Player_Stats; 


	public virtual void Buy(Upgrade newUpgrade)
	{
		// Add modifiers
		FindObjectOfType<Scr_Player_Stats>().OnSkillTreeChanged(newUpgrade);
		// Debug.Log(FindObjectOfType<Scr_Player_Stats>().name);
		
		// Debug.Log("Bought " + name);

	}

}