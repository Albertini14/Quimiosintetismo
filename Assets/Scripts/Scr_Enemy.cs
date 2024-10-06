using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Scr_Enemy : MonoBehaviour
{

	// On collide with enemy with inner trigger damage it.


	float TimeSinceDmg;
	[SerializeField] float CD = 2f;
	[SerializeField] bool CanAttack = true;

	void Update(){
		if(Time.time - TimeSinceDmg > CD){
			CanAttack = true;
		}
	}

	[SerializeField] Scr_Character_Stats en_stat;

	private void OnTriggerStay2D(Collider2D other){
		// Debug.LogWarning("collided");
		if (other.tag == "Player" && CanAttack)
		{
			// Debug.Log(FindObjectOfType<Scr_Player_Stats>().name);
			FindObjectOfType<Scr_Player_Stats>().TakeDamage(en_stat.Damage_Base.GetValue() * en_stat.Damage_Mult.GetValue());
			TimeSinceDmg = Time.time;
			CanAttack = false;
		} else if (other.tag ==	"Clone" && CanAttack){
			other.GetComponent<Scr_Character_Stats>().TakeDamage(en_stat.Damage_Base.GetValue() * en_stat.Damage_Mult.GetValue());
			TimeSinceDmg = Time.time;
			CanAttack = false;
		}
	}
}
