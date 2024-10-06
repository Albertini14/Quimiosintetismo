using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Clone_Mov : MonoBehaviour
{
	float TimeSinceAlive;

	// Start is called before the first frame update
	void Start()
    {
        TimeSinceAlive = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - TimeSinceAlive > 3){
			Destroy(this.gameObject);
		}
    }

}
