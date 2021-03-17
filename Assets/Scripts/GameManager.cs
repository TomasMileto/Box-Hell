using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public string sceneActual;
    InputField inputField;
    Timer timer;
    public float vidaPlayer = 100f;
    public GameObject inGameMenu, toInput, muteMusic;   
    bool menuOn, displayMenu, misilSumado=false, musicMuted;
    public bool playerMuerto, playerBoosted;
    public int numeroMisiles=12, enemigosAsesinados=0, enemigosParaMisil=10; public int score=0;
    public List<GameObject> listaEnemigos;


    float  randtime, randz, randx;
    public GameObject circuloBoost;
    Vector3 Where; public GameObject corazon;
    public float nextCorazon = 50f, minRandTime1, maxTRandTime1, nextCirculoBoost, minRandTime2, maxRandTime2;
    public UIManager UI;




    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(this.gameObject);
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        List<GameObject>  listaEmemigos = new List<GameObject>();
        Time.timeScale = 1f;
        UI = FindObjectOfType<UIManager>();
        sceneActual = scene.name;
        if (UI !=null)
            inGameMenu = UI.InGameMenu;
        if (UI != null)
            toInput = UI.toInput;
        if (UI != null)
            muteMusic = UI.muteMusic;
        print(inGameMenu);
        
        print("Escena Actual:"+sceneActual);

        menuOn = false;
        playerBoosted = false;
        if (UI !=null)      
            inGameMenu.SetActive(false);
      
    ///////////
      
        if (sceneActual == "Boxing" || sceneActual =="BoxingHard")
        {
            timer = FindObjectOfType<Timer>().GetComponent<Timer>();
            score = 0;
        }

        if (sceneActual == "BoxingHard")
        {
            enemigosParaMisil = 7;
            nextCorazon = 65;
            minRandTime1 = 20; minRandTime2 = 30;
            minRandTime2 = 30; maxRandTime2 = 40f;
            nextCirculoBoost = Random.Range(minRandTime2, maxRandTime2);
        }
        if (sceneActual == "Boxing")
        {
            enemigosParaMisil = 15;
            nextCorazon = 50;
            minRandTime1 = 10; minRandTime2 = 25;
            minRandTime2 = 20; maxRandTime2 = 35f;
            nextCirculoBoost = Random.Range(minRandTime2, maxRandTime2);
           
        }

       

    } 

    



    void Start()
    {

      
    }

    void Update()
        
    {   if (vidaPlayer <= 0) playerMuerto = true;
        /*******************************************************************************************************************************************/
        ////******************************************************** BOXING NORMAL ****************************************************************/////
        /*******************************************************************************************************************************************/
        if (sceneActual == "Boxing")
        {
            
            ///////////// IN GAME MENU//////////////////

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuOn == false)
                {
                    print("Estoy en el menu");
                    Time.timeScale = 0f;
                    menuOn = true;

                    if (inGameMenu != null)
                    { inGameMenu.SetActive(true); muteMusic.SetActive(true); }
                    AudioManager.Instance.Reproducir(AudioManager.Instance.openMenu);
                    //AudioManager.Instance.audioSource.Stop();

                }
                else
                {
                    print("No estoy en el menu");
                    Time.timeScale = 1f;
                    menuOn = false;
                    if (inGameMenu != null)
                    { inGameMenu.SetActive(false); muteMusic.SetActive(false); }
                    AudioManager.Instance.Reproducir(AudioManager.Instance.closeMenu);
                    //AudioManager.Instance.audioSource.Play();


                }

            }
            if (Input.GetKeyDown(KeyCode.R) && menuOn == true)
            {
                GoToScene("Boxing");
                
                
            }
            if (Input.GetKeyDown(KeyCode.Q) && menuOn == true)
            {
                GoToScene("Titulo");

            }

            if(Input.GetKeyDown(KeyCode.M) && menuOn == true)
            {
                if (!musicMuted)
                {
                    AudioManager.Instance.audioSource.Stop();
                    musicMuted = true;
                }
                else { AudioManager.Instance.audioSource.Play(); musicMuted = false; }
            }

            /////////////// CORAZON SPAWNER /////////////////

            if ( Time.timeSinceLevelLoad > nextCorazon)
            {
                print("Aparecio corazon");
                AudioManager.Instance.Reproducir(AudioManager.Instance.aparecioCorazon, vol: 2.5f);

                randtime = Random.Range(minRandTime1, maxTRandTime1);
                nextCorazon = Time.timeSinceLevelLoad + randtime;
                CrearRandomSpot(corazon, 1f, Quaternion.Euler(-60, 5, 0));
            }
            

            ///////////// CIRCULO BOOST SPAWNER//////////////

            if(Time.timeSinceLevelLoad > nextCirculoBoost)
            {
                print("Aparecio un circulo de boost");
                AudioManager.Instance.Reproducir(AudioManager.Instance.aparecioCirculo, vol: 1.2f);
                randtime = Random.Range(minRandTime2, maxRandTime2);
                nextCirculoBoost = Time.timeSinceLevelLoad + randtime;
                CrearRandomSpot(circuloBoost, 0.32f, Quaternion.identity);
            }

            //////////////////// MISILES ////////////////////////////   
            numeroMisiles = Mathf.Clamp(numeroMisiles, 0, 5);
            if (enemigosAsesinados % enemigosParaMisil == 0 && !misilSumado /*&&enemigosAsesinados!=0*/)
            {
                numeroMisiles++;
                misilSumado = true;
                if(numeroMisiles<5)
                AudioManager.Instance.Reproducir(AudioManager.Instance.nuevoMisil, vol: 3f);
            }
            else if (enemigosAsesinados % enemigosParaMisil != 0) misilSumado = false;
            
           
                
             

            ////////////// MUERTE PLAYER////////////////////


            if (playerMuerto==true)
            { score = timer.tiempofinal;
                {
                    if (displayMenu == false)
                    {
                        Invoke("displayRestart", 2.5f);
                        displayMenu = true;

                    }

                    if (Input.GetKeyDown(KeyCode.R))
                    {

                        GoToScene("Boxing");



                    }

                    if (Input.GetKeyDown(KeyCode.Q))
                    {

                        GoToScene("Titulo");


                    }
                    if (Input.GetKeyDown(KeyCode.I))
                    {
                        GoToScene("IngresarScore");
                    }
                }
            }
        }
        /*******************************************************************************************************************************************/
        ////********************************************************* BOXING INSANE ************************************************************/////
        /*******************************************************************************************************************************************/

        if (sceneActual == "BoxingHard")
        {
            ///////////// IN GAME MENU//////////////////

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (menuOn == false)
                {
                    print("Estoy en el menu");
                    Time.timeScale = 0f;
                    menuOn = true;

                    if (inGameMenu != null)
                    { inGameMenu.SetActive(true);muteMusic.SetActive(true); }
                    AudioManager.Instance.Reproducir(AudioManager.Instance.openMenu);

                }
                else
                {
                    print("No estoy en el menu");
                    Time.timeScale = 1f;
                    menuOn = false;
                    if (inGameMenu != null)
                    { inGameMenu.SetActive(false); muteMusic.SetActive(false); }
                    AudioManager.Instance.Reproducir(AudioManager.Instance.closeMenu);


                }

            }
            if (Input.GetKeyDown(KeyCode.R) && menuOn == true)
            {
                GoToScene("BoxingHard");

            }
            if (Input.GetKeyDown(KeyCode.Q) && menuOn == true)
            {
                GoToScene("Titulo");

            }
            if (Input.GetKeyDown(KeyCode.M) && menuOn == true)
            {
                if (!musicMuted)
                {
                    AudioManager.Instance.audioSource.Stop();

                    musicMuted = true;
                }
                else { AudioManager.Instance.audioSource.Play(); musicMuted = false; }
            }

            /////////////// CORAZON SPAWNER /////////////////

            if (Time.timeSinceLevelLoad > nextCorazon)
            {
                print("Aparecio corazon");
                AudioManager.Instance.Reproducir(AudioManager.Instance.aparecioCorazon, vol: 2.5f);

                randtime = Random.Range(minRandTime1, maxTRandTime1);
                nextCorazon = Time.timeSinceLevelLoad + randtime;
                CrearRandomSpot(corazon, 1f, Quaternion.Euler(-60, 5, 0));
            }


            ///////////// CIRCULO BOOST SPAWNER//////////////

            if (Time.timeSinceLevelLoad > nextCirculoBoost)
            {
                print("Aparecio un circulo de boost");
                AudioManager.Instance.Reproducir(AudioManager.Instance.aparecioCirculo, vol: 1.2f);
                randtime = Random.Range(minRandTime2, maxRandTime2);
                nextCirculoBoost = Time.timeSinceLevelLoad + randtime;
                CrearRandomSpot(circuloBoost, 0.32f, Quaternion.identity);
            }

            //////////////////// MISILES ////////////////////////////   
            numeroMisiles = Mathf.Clamp(numeroMisiles, 0, 5);
            if (enemigosAsesinados % enemigosParaMisil == 0 && !misilSumado /*&&enemigosAsesinados!=0*/)
            {
                numeroMisiles++;
                misilSumado = true;
                if (numeroMisiles < 5)
                    AudioManager.Instance.Reproducir(AudioManager.Instance.nuevoMisil, vol: 3f);
            }
            else if (enemigosAsesinados % enemigosParaMisil != 0) misilSumado = false;





            ////////////// MUERTE PLAYER////////////////////


            if (playerMuerto == true)
            {
                if (displayMenu == false)
                {
                    Invoke("displayRestart", 2.5f);
                    displayMenu = true;


                }

                if (Input.GetKeyDown(KeyCode.R))
                {

                    GoToScene("BoxingHard");



                }

                if (Input.GetKeyDown(KeyCode.Q))
                {

                    GoToScene("Titulo");


                }

                if (Input.GetKeyDown(KeyCode.I))
                {
                    GoToScene("IngresarScore");
                }
            }
        }

        if (sceneActual == "IngresarScore")
        {
            if (Input.GetButtonDown("Submit"))
            {
                print("A escena");
                GoToScene();
            }
        }


    }


    void displayRestart()
    {
        if (inGameMenu != null)
        { print("funcion mal parida llamada");
            inGameMenu.SetActive(true);
            if (playerMuerto)
            {  if(UI!=null)
                toInput.SetActive(true);
            }
        }

    }

   void CrearRandomSpot(GameObject objeto, float altura, Quaternion rotacion)
    {
        randx = Random.Range(-17f, 17f);
        randz = Random.Range(-16f, 16f);
        Where = new Vector3(randx, altura, randz);
        Instantiate(objeto, Where, rotacion);
    }


    public void GoToScene(string nombre="Titulo")
    {
        SceneManager.LoadScene(nombre);
        GameManager.Instance.vidaPlayer = 100;
        if (UI != null)
        { toInput.SetActive(false); }
        Time.timeScale = 1f;
        Timer.i = 1;
        menuOn = false;
        musicMuted = false;
        playerMuerto = false;
        displayMenu = false;
        listaEnemigos.Clear();
        enemigosAsesinados = 0;
        numeroMisiles = 0;
        AudioManager.Instance.gameOverBool = false;
        CancelInvoke("displayRestart");
    }

   
}