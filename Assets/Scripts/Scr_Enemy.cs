using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Scr_Enemy : MonoBehaviour
{

	// On collide with enemy with inner trigger damage it.

	[SerializeField] Scr_Character_Stats en_stat;

	private void OnTriggerEnter2D(Collider2D other){
		Debug.LogWarning("collided");
		if (other.tag == "Player")
		{
			Debug.Log(FindObjectOfType<Scr_Player_Stats>().name);
			FindObjectOfType<Scr_Player_Stats>().TakeDamage(en_stat.Damage_Base.GetValue() * en_stat.Damage_Mult.GetValue());
		}
	}
}
