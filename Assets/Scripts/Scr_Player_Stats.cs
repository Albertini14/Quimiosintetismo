using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

[CreateAssetMenu(menuName = "Players Stats")]
public class Scr_Player_Stats : ScriptableObject
{

	public Dictionary<Stat, float> stats = new Dictionary<Stat, float>();

	public float GetStat(Stat stat)
	{
		if(stats.TryGetValue(stat, out float value)){
			return value;
		}
		else{
			Debug.LogError("Stat " + stat + " not found");
			return 0;
		}
	}

	public void ChangeStat(Stat stat, float amount){
		if(stats.TryGetValue(stat, out float value)){
			stats[stat] += amount;
		}
		else{
			Debug.LogError("Stat " + stat + " not found to change");
		}
	}

	public enum Stat
	{
		Health_Base,
		Health_Mult,
		Movement_Speed_Base,
		Movement_Speed_Mut
	}

}



