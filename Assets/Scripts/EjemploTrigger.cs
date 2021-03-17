using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        print(other); //Other es el objeto con el se detectó la colisión  
    }
}
