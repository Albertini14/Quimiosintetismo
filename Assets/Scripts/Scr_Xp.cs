using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Xp : MonoBehaviour
{
    public float xp_value = 1;

	private void OnTriggerEnter2D(Collider2D other){
		Debug.Log("col");
		if(other.tag == "Player"){
			FindAnyObjectByType<Scr_Player_Stats>().GainXp(xp_value);
			Destroy(this.gameObject);
		}
	}
}
