    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1mover : MonoBehaviour {

    GameObject Player; public GameObject enLlamas, fuego; bool onFire; Vector3 whereLLamas;
    public float velocidadMovimiento=5f;
    float nextLlama=0;
    const float EPSILON= 0.1f;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        

    }

    private void Update()
    {
        whereLLamas = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f);
    }

    void FixedUpdate()
    {
        if (Player == null) return;


        float paso = velocidadMovimiento * Time.deltaTime;



        if ((transform.position - Player.transform.position).magnitude > EPSILON && transform.position.y < 2)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, paso);
            transform.LookAt(Player.transform.position);
        }

        if (GameManager.Instance.sceneActual == "BoxingHard")
        {
            if (onFire)
            {
                LlamasAMi();
            }
        }

       
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "LlamaCollider")
        {
            onFire = true;
        }
    }

    void LlamasAMi()
    {
        enLlamas.SetActive(true);
        if (nextLlama < Time.timeSinceLevelLoad)
        {
            nextLlama = Time.timeSinceLevelLoad + 0.1f;
            Instantiate(fuego, whereLLamas, Quaternion.identity);
        }
    }
}