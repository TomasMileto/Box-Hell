using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo3Motor : MonoBehaviour {


    GameObject player;
    public GameObject bala;
    public Transform shotSpawn1, shotSpawn2;
    public float fireRate = 2f, duracionLlama = 4f; public GameObject spawnLlama;
    bool llamaOn;
    float nextFire=0f, nextLlama, countdown;
    

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player"); 
        nextLlama=Time.timeSinceLevelLoad+3f;
        if (GameManager.Instance.sceneActual == "BoxingHard")
        {
            countdown = duracionLlama;
            
        }


    }
	
	
	void Update () {

        if (player == null) return; 
        if (transform.position.y < 2f) 
        {
            transform.LookAt(player.transform.position); 
        }

        if (Time.timeSinceLevelLoad > nextFire && transform.position.y < 2f && transform.position.y >0f)

        {
            nextFire = Time.timeSinceLevelLoad + fireRate;
            Instantiate(bala, shotSpawn1.position, shotSpawn1.rotation);
            Instantiate(bala, shotSpawn2.position, shotSpawn2.rotation);
            AudioManager.Instance.Reproducir(AudioManager.Instance.disparoEnemigo);
        }

        if (GameManager.Instance.sceneActual == "BoxingHard")
        {
            if(Time.timeSinceLevelLoad > nextLlama)
            {
                nextLlama= Time.timeSinceLevelLoad + Random.Range(6.5f, 12f);
                nextFire = Time.timeSinceLevelLoad + duracionLlama+1.2f;
                spawnLlama.SetActive(true);
                AudioManager.Instance.Reproducir(AudioManager.Instance.flameThrower);
            }
            if (spawnLlama.activeSelf == true)
            {
                countdown -= Time.deltaTime;
            }
            if (countdown <= 0)
            {
                spawnLlama.SetActive(false);
                countdown = duracionLlama;
                
            }
        }

    }
        

    
}
