
using UnityEngine;

[CreateAssetMenu(fileName = "New Upgrade", menuName = "SkillTree/Skill")]
public class Skill : Upgrade
{

	public int min_level = 1;
	public int max_level = 5;

	public void Buy(Skill newSkill)
	{
		// Add modifiers
		FindObjectOfType<Scr_Player_Stats>().OnSkillTreeChanged(newSkill);
		// Debug.Log(FindObjectOfType<Scr_Player_Stats>().name);

		// Debug.Log("Bought " + name);

		FindObjectOfType<Scr_Player_Stats>().OnSkillGained(newSkill);

	}

}
