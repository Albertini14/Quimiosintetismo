using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scr_Player_Movement : MonoBehaviour
{

	Vector2 movement;
	public Scr_Player_Stats Stats;
	//public float speed;

	public Rigidbody2D rb;

	void Start(){
		Stats = FindAnyObjectByType<Scr_Player_Stats>();
	}

    // Update is called once per frame
    void Update()
    {
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");	
		if (movement.x > 0){
			GetComponentInChildren<SpriteRenderer>().flipX = true;
		}
		else if (movement.x < 0){
			GetComponentInChildren<SpriteRenderer>().flipX = false;
		}
	}

	void FixedUpdate(){
		rb.MovePosition(rb.position + movement * (Stats.Speed_Base.GetValue() * Stats.Speed_Mult.GetValue()) * Time.fixedDeltaTime);
	}

}
