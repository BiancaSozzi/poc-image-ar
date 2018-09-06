using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerPreMatch : MonoBehaviour {

    public Text timer_text;
    private float start_time;
    private float time_remaining = 10; // in seconds

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        time_remaining -= Time.deltaTime;

        if(time_remaining <= 0){
            timer_text.text = "MATCH BEGINS";
        }else{


            string seconds = (time_remaining % 60).ToString("f0");
            if ((time_remaining % 60) < 10)
            {
                seconds = "0" + seconds;
            }else if(seconds == "60"){
                seconds = "00";
            }


            string minutes = ((int)(time_remaining / 60)).ToString();
            if (((time_remaining / 60)) < 10)
            {
                minutes = "0" + minutes;
            }


            string hours = ((int)time_remaining / 3600).ToString();
            if ((time_remaining / 3600) < 10)
            {
                hours = "0" + hours;
            }

            timer_text.text = hours + ':' + minutes + ':' +  seconds;
            }

	}

}
