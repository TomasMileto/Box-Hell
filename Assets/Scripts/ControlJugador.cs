using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJugador : MonoBehaviour {

    public float velocidad = 3.3f;
    public float velocidadRotacion = 1f;
    public float fireRate;
    
    private float nextFire, nextSound, nextSound2;
    public Transform shotSpawn, misilSpawn;
    public GameObject shot, sangre, Missile, electrified, misil1, misil2, misil3, misil4, misil5;
    Vector3 localPosition;
    private Vector3 tempPos;
    bool inBoost;
    
    Renderer colorPlayer; Animator animator;
    void Start() {

      // vida = 100f;
        BoostBar boostBar = GameObject.Find("BarraBoost").GetComponent<BoostBar>();
        /*GameManager.Instance.inGameMenu.SetActive(false);*/

    }


    private void Update() {
        //////////////// INPUTS ///////////////////////
        

        /////BOOST
        ///
        if (Input.GetKey(KeyCode.Space) && BoostBar.boost > 0)
            if (Time.timeSinceLevelLoad > nextSound)
            {
                nextSound = Time.timeSinceLevelLoad + 0.65f;
                AudioManager.Instance.Reproducir(AudioManager.Instance.electrified);
            }

        if (Input.GetKeyDown(KeyCode.Space) && BoostBar.boost > 0)
        {
            print("HABEEEEEERE");
            GameManager.Instance.playerBoosted = true;
            colorPlayer = GetComponent<Renderer>();
            animator = GetComponent<Animator>();
            animator.SetBool("Boosted", true);
            colorPlayer.material.SetColor("_Color", Color.blue);
            electrified.SetActive(true);

            fireRate *= 0.4f;
            velocidad *= 2f;
            velocidadRotacion += 6f;

            AudioManager.Instance.Reproducir(AudioManager.Instance.boosted, vol: 2.5f);
        } else if (GameManager.Instance.playerBoosted == true)
        {
            print("Player boosted");
            if (BoostBar.boost <=0)
            {
                animator = GetComponent<Animator>();
                animator.SetBool("Boosted", false);
                fireRate /= 0.4f;
                velocidad /= 2f;
                velocidadRotacion -= 6;
                GameManager.Instance.playerBoosted = false;
                AudioManager.Instance.Reproducir(AudioManager.Instance.unboosted, vol: 1.2f);
                electrified.SetActive(false);

            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                
                animator = GetComponent<Animator>();
                animator.SetBool("Boosted", false);
                fireRate /= 0.4f;
                velocidad /= 2f;
                velocidadRotacion -= 6;
                GameManager.Instance.playerBoosted = false;
                AudioManager.Instance.Reproducir(AudioManager.Instance.unboosted);
                electrified.SetActive(false);
            }
        }
        
        



        //////DISPARO
        ///
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            AudioManager.Instance.Reproducir(AudioManager.Instance.disparoPlayer); 
        }
        //////MISILES
        ///
        if(Input.GetButtonDown("Fire2"))
        { 
            if (GameManager.Instance.numeroMisiles > 0 && GameManager.Instance.listaEnemigos.Count > 0)
            {
                Invoke("DispararMisil", 0.35f);
                animator = GetComponent<Animator>();
                animator.SetBool("Fired", true);
                
            }
            else AudioManager.Instance.Reproducir(AudioManager.Instance.misilError, vol: 3f);
        }

        switch (GameManager.Instance.numeroMisiles)
        {
            case 5:
                misil5.SetActive(true);
                break;
            case 4:
                misil4.SetActive(true);
                misil5.SetActive(false);
                break;
            case 3:
                misil3.SetActive(true);
                misil4.SetActive(false);
                break;
            case 2:
                misil2.SetActive(true);
                misil3.SetActive(false);
                break;
            case 1:
                misil1.SetActive(true);
                misil2.SetActive(false);
                break;
            case 0:
                misil1.SetActive(false);
                break;

        }


        ///////////////////MUERTE//////////////////////////////
        GameManager.Instance.vidaPlayer = Mathf.Clamp(GameManager.Instance.vidaPlayer, 0f, 100f);
        if (GameManager.Instance.vidaPlayer <= 0)
        {
            
            gameObject.SetActive(false);
            Instantiate(sangre, transform.position, Quaternion.identity);
            GameManager.Instance.playerMuerto = true;
            

        }


    }
    

    //********* COLISIONES ************//
    private void OnCollisionEnter(Collision other)
    {

        print("Colisiono con:  " + other.gameObject);
        if (other.gameObject.tag.Equals("Enemigo"))
        {
            AudioManager.Instance.Reproducir(AudioManager.Instance.damagePlayer, 3f);


            GameManager.Instance.vidaPlayer-= 6;
            
            
        }
        

      
       
    }
    private void OnTriggerEnter(Collider other)
    {

        print("Colisiono con:  " + other.gameObject);
        
        if (other.gameObject.tag.Equals("BalaEnemigo"))
        { BalaEnemigo balaEnemigo = other.gameObject.GetComponent<BalaEnemigo>();
            if (balaEnemigo != null) {
                GameManager.Instance.vidaPlayer -=balaEnemigo.damage;
                AudioManager.Instance.Reproducir(AudioManager.Instance.damagePlayer, 3f);

            }
        }

        if (other.gameObject.tag.Equals("MartilloEnemigo"))
        {
            AudioManager.Instance.Reproducir(AudioManager.Instance.colisionMartillo, 3f);
            AudioManager.Instance.Reproducir(AudioManager.Instance.damagePlayer);

            GameManager.Instance.vidaPlayer -= 15;
        }


       
    }
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag.Equals("Fuego"))
        {
            Fuego fuego = other.gameObject.GetComponent<Fuego>();
            if (fuego != null)
            {
                GameManager.Instance.vidaPlayer -= fuego.damage*Time.deltaTime;
                if (Time.timeSinceLevelLoad > nextSound2)
                {
                    nextSound2 = Time.timeSinceLevelLoad + 0.4f;
                    AudioManager.Instance.Reproducir(AudioManager.Instance.damagePlayer);
                }

            }
        }
    }

    void FixedUpdate()
    {
        /////////// APUNTAR A MOUSE///////////////////
        
        Plane planoJugador = new Plane(Vector3.up, transform.position);

        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        
        float hitdist = 0.0f;
        
        if (planoJugador.Raycast(ray, out hitdist))
        {
            
            Vector3 objetivo = ray.GetPoint(hitdist);

            
            Quaternion targetRotation = Quaternion.LookRotation(objetivo - transform.position);

            
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, velocidadRotacion * Time.deltaTime);
        }



        //////////////// MOVIMIENTO /////////////////

        Vector3 tempPos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            tempPos.z += velocidad*Time.deltaTime;
            transform.position = tempPos;

        }

        if (Input.GetKey(KeyCode.S))
        {
            tempPos.z -= velocidad*Time.deltaTime;
            transform.position = tempPos;

        }
        if (Input.GetKey(KeyCode.A))
        {
            tempPos.x -= velocidad* Time.deltaTime;
            transform.position = tempPos;

        }

        if (Input.GetKey(KeyCode.D))
        {  
            tempPos.x += velocidad* Time.deltaTime;
            transform.position = tempPos;

        }

        
    }

    void DispararMisil()
    {
        Instantiate(Missile, misilSpawn.position, Quaternion.Euler(-90, 45, 45));
        AudioManager.Instance.Reproducir(AudioManager.Instance.misilPlayer);
        GameManager.Instance.numeroMisiles--;
        animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        animator.SetBool("Fired", false);

    }

} 
