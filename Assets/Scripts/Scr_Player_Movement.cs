using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class Scr_Player_Movement : MonoBehaviour
{

	Vector2 movement;
	[SerializeField] Scr_Player_Stats Stats;
	//public float speed;

	public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");	
	}

	void FixedUpdate(){
		rb.MovePosition(rb.position + movement * (Stats.Speed_Base.GetValue() * Stats.Speed_Mult.GetValue()) * Time.fixedDeltaTime);
	}

}
