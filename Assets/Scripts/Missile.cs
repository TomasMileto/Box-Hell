using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile  : MonoBehaviour {
    
    int indexLista;
    public float velocidadMisilInicial, velocidadMisilVuelo, rotacion;
    Vector3 objetivo;
    GameObject enemigoObjetivo; public GameObject explosion;
    public float damage=30f, radioExplosion=5f, fuerzaExplosion=800f;
    


    public bool missileReady, exploded;
	void Start () {
        
        print("Despegue de misil");

        
        indexLista = Random.Range(0, GameManager.Instance.listaEnemigos.Count);
        

    }
    private void Update()
    {
        
            if (transform.position.y > 10f)
            {
               missileReady=true;
            }
            enemigoObjetivo = GameManager.Instance.listaEnemigos[indexLista];
        if (enemigoObjetivo == null)
        {
            switch (GameManager.Instance.listaEnemigos.Count)
            {
                case 0:
                    Explode();
                    break;
                default:
                    indexLista = Random.Range(0, GameManager.Instance.listaEnemigos.Count);
                    enemigoObjetivo = GameManager.Instance.listaEnemigos[indexLista];
                    break;

            }

        }

    }
    void FixedUpdate () {

        float step = velocidadMisilVuelo * Time.deltaTime;

        //Plane planoJugador = new Plane(Vector3.up, transform.position);


        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


        //float hitdist = 0.0f;

        //if (planoJugador.Raycast(ray, out hitdist))
        //{

        //  Vector3 objetivo = ray.GetPoint(hitdist);
        if (!exploded)
        {
            if (missileReady)
            {
                if (GameManager.Instance.listaEnemigos.Count != 0)
                {
                    print("Locked target:" + enemigoObjetivo.name);
                    Vector3 objetivo = enemigoObjetivo.transform.position;
                    Quaternion targetRotation = Quaternion.LookRotation(objetivo - transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotacion * Time.deltaTime);

                    transform.position = Vector3.MoveTowards(transform.position, objetivo, step);
                }
                else Explode();


            }

            // }

            if (!missileReady)
            {
                transform.Translate(0, 0, velocidadMisilInicial * Time.deltaTime);

            }
        }

    }
    private void OnTriggerEnter (Collider collider)
    {
        if (missileReady && collider.gameObject.tag!="Player")
            Explode();
    }
    void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        AudioManager.Instance.Reproducir(AudioManager.Instance.explosionMisil, vol: 4f);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radioExplosion);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fuerzaExplosion, transform.position, radioExplosion);
                rb.AddForce(new Vector3(0, fuerzaExplosion / 2, 0));
                if (nearbyObject.gameObject.tag == "Enemigo")
                {
                    VidaEnemigo vidaEnemigo = nearbyObject.gameObject.GetComponent<VidaEnemigo>();
                   if (vidaEnemigo != null) vidaEnemigo.vida -= damage;
                }
            }
        }
        exploded = true;
        
        Destroy(this.gameObject, 1.2f);
    }
   
}
