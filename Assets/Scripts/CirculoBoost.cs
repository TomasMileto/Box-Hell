using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CirculoBoost : MonoBehaviour {

    
    public float duracion=10f; float countdown1;
    public float recargandoBoost;
    float next;
    public GameObject sparks;
    ParticleSystem thisPS;



    private void Start()
    {
        sparks.SetActive(false);
        countdown1 = duracion;
        BoostBar boostBar = GameObject.Find("BarraBoost").GetComponent<BoostBar>();
        thisPS = this.gameObject.GetComponent<ParticleSystem>();
    }
    void Update () {

      countdown1 = countdown1 - Time.deltaTime;

        if (countdown1 <= 0)
        {
            
            Destroy(this.gameObject);

        }
        if (countdown1 <= 1|| BoostBar.boost>=199)
        {

            sparks.SetActive(false);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            
            
          
            
        }
    }
    private void OnTriggerStay(Collider other)
    {   
        print("Player en circulo de boost");
        if (other.gameObject.tag == "Player")
        {
            BoostBar.boost += recargandoBoost * Time.deltaTime;
            sparks.SetActive(true);
            if (Time.time > next && BoostBar.boost<200)
            {
                next = Time.time + 0.8f;
                AudioManager.Instance.Reproducir(AudioManager.Instance.boosting);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            sparks.SetActive(false);  

        }


    }

    
    
}
