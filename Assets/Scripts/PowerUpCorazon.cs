using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class PowerUpCorazon : MonoBehaviour {
    float time;
    float vidaRecup;
    public GameObject sangre, healUp;
    public int vida1, vida2, vida3, vida4, vida5;

	void Start () {
        time = 0;
        
	}
	
	void Update () {
       time += Time.deltaTime;
       
        if (time > 6.5f) DestruirCorazon();
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           
            
            print("Player tomo corazon");
            if (time > 5f) { GameManager.Instance.vidaPlayer += vida5; DestruirCorazon(); }
            else if (time > 4f) { GameManager.Instance.vidaPlayer += vida4; DestruirCorazon(); }
            else if (time > 3f) { GameManager.Instance.vidaPlayer += vida3; DestruirCorazon(); }
            else if (time > 2f) { GameManager.Instance.vidaPlayer+= vida2; DestruirCorazon();}
            else if (time >= 0.4f)   {GameManager.Instance.vidaPlayer += vida1; DestruirCorazon(); }
            else if (time>=0f){GameManager.Instance.vidaPlayer += 2; DestruirCorazon(); }

           
                
            
        }

    }

    void DestruirCorazon()
    {
        Destroy(this.gameObject);
        if (time > 6.5)
        {
            Instantiate(sangre, transform.position, Quaternion.identity);
            AudioManager.Instance.Reproducir(AudioManager.Instance.chauCorazon);
        }
        else {
            Instantiate(healUp, transform.position, Quaternion.identity);
            AudioManager.Instance.Reproducir(AudioManager.Instance.agarrarCorazon);
        }
        
    }
}
