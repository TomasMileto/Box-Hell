using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparador : MonoBehaviour {

    public float ratioDisparo = 0.05f;
    public GameObject bala;

	void Start () {
        InvokeRepeating("DispararBala", ratioDisparo, ratioDisparo);
	}
	
	
	

    void DispararBala()
    {
        Instantiate(bala, transform.position, transform.rotation);
    }
}
