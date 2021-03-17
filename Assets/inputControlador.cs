using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputControlador : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}
    public void GetInput(string guest = "Montaraz")
    {

        print("Nombre=" + guest + ". Tiempo Final=" + GameManager.Instance.score);
        
        LeaderBoardScript.Instance.AgregarHighScore(guest, GameManager.Instance.score);
        


    }
}
