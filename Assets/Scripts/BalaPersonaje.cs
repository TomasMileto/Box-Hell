using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPersonaje : MonoBehaviour
{

    public int velocidad = 5;
    public float damage = 15f;
    Renderer colorBala;

    private void Start()
    {
        colorBala = this.gameObject.GetComponent<Renderer>();
    }
    void Update()
    {
        Destroy(gameObject, 2f);
        gameObject.transform.Translate(0.0f, 0.0f, velocidad * Time.deltaTime);

        if (GameManager.Instance.playerBoosted == true)
        {
            colorBala.material.SetColor("_Color", Color.blue);
        }else colorBala.material.SetColor("Color_", Color.red);

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    
}


    