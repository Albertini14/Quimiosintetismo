using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scr_Timer : MonoBehaviour
{

	[SerializeField] float start_time;
	[SerializeField] float end_time;
	public float time2evolve = 9000000;
	float time2text;
	[SerializeField] TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        start_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        time2text = time2evolve - ((Time.time - start_time) / end_time * time2evolve); 
		txt.text = time2text.ToString("n0") + " years";

		//on reaching 0 die
		if(time2text <= 0){
			FindObjectOfType<Scr_Game_Manager>().RestartScene();
		}
    }
}
