    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour {
    public GameObject sangre;
    public float vida = 30; 

	void Update () {
	        if (vida <=0)
        {
            GameManager.Instance.enemigosAsesinados++;
            Instantiate(sangre, transform.position, Quaternion.identity);

            if (this.gameObject.name == "Enemigo1(Clone)" || this.gameObject.name == "Enemigo1.Hard(Clone)")
                AudioManager.Instance.Reproducir(AudioManager.Instance.muerteEnemigo1, vol:0.7f);
            if(this.gameObject.name == "Enemigo2(Clone)" || this.gameObject.name == "Enemigo2.Hard(Clone)")
                AudioManager.Instance.Reproducir(AudioManager.Instance.muerteEnemigo2, vol:0.7f);
            if (this.gameObject.name == "Enemigo3(Clone)" || this.gameObject.name == "Enemigo3.Hard(Clone)")
                AudioManager.Instance.Reproducir(AudioManager.Instance.muerteEnemigo3, vol:0.7f);
            GameManager.Instance.listaEnemigos.Remove(this.gameObject);
            Destroy(gameObject);



        }
    }
    private void OnTriggerEnter(Collider other)
        
    {

        if (other.tag.Equals("Bala"))
        { BalaPersonaje bala = other.gameObject.GetComponent<BalaPersonaje>();
            vida -= bala.damage;
            if(vida>0)
                if (this.gameObject.name == "Enemigo1(Clone)" || this.gameObject.name == "Enemigo1.Hard(Clone)")
                    AudioManager.Instance.Reproducir(AudioManager.Instance.enemigo1Golpeado, 0.7f);
                if (this.gameObject.name == "Enemigo2(Clone)" || this.gameObject.name == "Enemigo2.Hard(Clone)")
                AudioManager.Instance.Reproducir(AudioManager.Instance.enemigo2Golpeado, 0.7f);
                if (this.gameObject.name == "Enemigo3(Clone)" || this.gameObject.name == "Enemigo3.Hard(Clone)")
                AudioManager.Instance.Reproducir(AudioManager.Instance.enemigo3Golpeado, 0.7f);

        }
    }
}

