using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

    Text timer;
    
    float seconds, minutes;public int tiempofinal=-1;
    public bool updateOn=true;
    public static int i = 1;

	void Start () {
        timer = GetComponent<Text>();
            
    }
	
	
	void FixedUpdate () {
        
        
        if (!GameManager.Instance.playerMuerto )
        {
            
            seconds = (int)(Time.timeSinceLevelLoad % 60f);
            minutes = (int)(Time.timeSinceLevelLoad / 60f);
            timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            
        }
        else 
            {
                if (i == 1)
                {

                    tiempofinal = (int)Time.timeSinceLevelLoad;
                    seconds = (int)(tiempofinal % 60f);
                    minutes = (int)(tiempofinal / 60f);
                    timer.text = minutes.ToString("00") + ":" + seconds.ToString("00");
                    i++;
                }

        }
    }

    
}
