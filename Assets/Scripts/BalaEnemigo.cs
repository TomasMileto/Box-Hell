using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaEnemigo : MonoBehaviour
{

    public int velocidad = 5;
    public float damage = 9f;
    
    void Update()
    {
        Destroy(gameObject, 4f);
        gameObject.transform.Translate(0.0f, 0.0f, velocidad * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player")){
            Destroy(gameObject); }
    }

    
}


    