using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour {
    public float tiempoDeDestruccion;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, tiempoDeDestruccion);
        
	}
}
