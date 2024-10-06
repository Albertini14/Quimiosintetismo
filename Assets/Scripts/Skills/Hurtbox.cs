using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{

	public float dmg;

	float TimeSinceCreated;

    // Start is called before the first frame update
    void Start()
    {
        TimeSinceCreated = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - TimeSinceCreated > 1){
			Destroy(this.gameObject);
		}
    }
	

	private void OnTriggerEnter2D(Collider2D other)
	{
		// Debug.LogWarning("collided");
		if (other.tag == "Enemy")
		{
			FindObjectOfType<Scr_Character_Stats>().TakeDamage(dmg);
		}
	}
}
