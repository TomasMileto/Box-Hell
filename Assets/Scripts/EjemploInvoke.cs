using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploInvoke : MonoBehaviour {

	
	void Start () {
        Invoke("EscribirEnPantallla", 1f);

        InvokeRepeating("EscribirEnPantallla", 0f, 0.5f);

	}
	
	
	void Update () {
		
	}
    void EscribirEnPantallla()
    {
        print("Se llamo el invoke");
    }
}
