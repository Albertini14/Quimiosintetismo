using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

	Vector2 movement;
	public float speed;

	public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");	
	}

	void FixedUpdate(){
		rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
	}

}
