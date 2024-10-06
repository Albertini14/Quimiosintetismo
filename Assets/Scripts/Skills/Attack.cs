using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

	[SerializeField] bool CanAttack = true;
	[SerializeField] float CD = 3;
	[SerializeField] float timeSinceAttack = 0;

	[SerializeField] GameObject Hurt;

	void Update()
	{
		if (Time.time - timeSinceAttack > CD && !CanAttack) { CanAttack = true; }
	}

	// Update is called once per frame
	void FixedUpdate()
	{
		if (CanAttack && Input.GetMouseButtonDown(1))
		{
			timeSinceAttack = Time.time;
			CanAttack = false;
			Tack();
		}
	}

	void Tack()
	{
		GameObject obj = Instantiate(Hurt, transform.position, transform.rotation);
		obj.GetComponent<Hurtbox>().dmg = FindAnyObjectByType<Scr_Player_Stats>().Damage_Base.GetValue() * FindAnyObjectByType<Scr_Player_Stats>().Damage_Mult.GetValue();
	}
}
