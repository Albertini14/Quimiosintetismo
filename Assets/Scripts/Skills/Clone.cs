using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D.IK;
using UnityEngine.UIElements;

public class Clone : MonoBehaviour
{

	[SerializeField] bool CanTeleport = true;
	[SerializeField] float CD = 3;
	[SerializeField] float timeSinceTp = 0;

	[SerializeField] GameObject clone;
	
	void Update(){
		if(Time.time - timeSinceTp > CD && !CanTeleport) {CanTeleport = true;}
	}

    // Update is called once per frame
    void FixedUpdate()
    {

		if(CanTeleport && Input.GetMouseButtonDown(0))
		{
			timeSinceTp = Time.time;
			CanTeleport = false;
			Teleport();
		}


		void Teleport(){
			Vector3 mousePosition = Input.mousePosition;
			mousePosition.z = 5f;
			Vector2 v = Camera.main.ScreenToWorldPoint(mousePosition);
			Collider2D[] col = Physics2D.OverlapPointAll(v);
			CreateReplica();
			if (col.Length == 0)
			{
				this.transform.position += Vector3.Scale(Input.mousePosition, new Vector3(18 / 1920f, 10 / 1080f, 0)) - new Vector3(9, 5, 0);
			}
		}

		
		void CreateReplica(){
			GameObject cl = Instantiate(clone, this.transform.position, this.transform.rotation);
		}


	}


}
