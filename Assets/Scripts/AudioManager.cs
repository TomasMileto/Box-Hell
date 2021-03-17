using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip disparoEnemigo, disparoPlayer, misilPlayer, explosionMisil, misilError, nuevoMisil, muerteEnemigo1, muerteEnemigo2, muerteEnemigo3, enemigo1Golpeado,
        enemigo2Golpeado, enemigo3Golpeado, damagePlayer, colisionMartillo, openMenu, closeMenu, 
        aparecioCorazon, crecioCorazon, agarrarCorazon, chauCorazon, boosting, boosted, unboosted,
        electrified, aparecioCirculo, flameThrower, muertePlayer, gameOver;
    bool menuOn; public bool gameOverBool;


    /////////// SINGLETON ///////////////////
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /**************** CONSEGUIR AUDIOSORCE *****************************/
    void Start()
    {  
       
    }

    void Update()
    { /********************** UI *********************************/

        audioSource = Camera.main.GetComponent<AudioSource>();
        if(GameManager.Instance.sceneActual=="Boxing"|| GameManager.Instance.sceneActual=="BoxingHard")
        if (GameManager.Instance.playerMuerto)
        {
            if (!gameOverBool)
            {
                Reproducir(muertePlayer, 3f);
                audioSource.Pause();
                audioSource.clip = gameOver;
                audioSource.PlayDelayed(0.3f);
                gameOverBool = true;
                audioSource.loop = false;
            }
        }

    }



    public void Reproducir(AudioClip x, float vol = 1f)
    {  if(audioSource!=null)
        audioSource.PlayOneShot(x,vol);
        
    }
}
