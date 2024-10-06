using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class Scr_Enemy_Movement : MonoBehaviour
{

	//Detect player on outer collider and follow it

	[SerializeField] Scr_Character_Stats en_stat;

	[SerializeField] CircleCollider2D hurtbox;
	[SerializeField] CircleCollider2D detectZone;

	[SerializeField] float AggroDis = 10;

	[SerializeField] bool following = false;
	[SerializeField] GameObject prey;


	// Start is called before the first frame update
	void Start()
    {
        hurtbox.enabled = false;
		detectZone.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (following && prey != null){
			transform.position = Vector2.MoveTowards(transform.position, prey.transform.position, en_stat.Speed_Base.GetValue() * en_stat.Speed_Mult.GetValue() * Time.deltaTime);
		}

		if (prey == null && following)
		{
			
			Debug.Log("prey does not exist");
			prey = null;
			following = false;
			hurtbox.enabled = false;
			detectZone.enabled = true;
		} 
		else if (prey != null && Vector3.Distance(transform.position, prey.transform.position) > AggroDis)
		{
			following = false;
			hurtbox.enabled = false;
			detectZone.enabled = true;

		} 

	}


	private void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player" || other.tag == "Clone"){
			following = true;
			prey = other.gameObject;
			detectZone.enabled = false;
			hurtbox.enabled = true;
		}
	}
}
