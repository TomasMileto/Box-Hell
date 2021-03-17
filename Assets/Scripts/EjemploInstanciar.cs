using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploInstanciar : MonoBehaviour {

    public GameObject objetoAInstanciar;

	void Start () {
        Instantiate(objetoAInstanciar, transform.position, transform.rotation);

        
	}
	
	
	void Update () {
		
	}
}
