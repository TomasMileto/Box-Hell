using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo2Mover : MonoBehaviour {

    public float velocidadRotacion = 5f;
    public float velocidadMovimiento= 5f;
    const float EPSILON = 0.1f;
    GameObject Player;


    void Start () {

       Player= GameObject.FindGameObjectWithTag("Player"); 
       
		
	}
	

	void Update () {
        if (Player == null) return;
        velocidadRotacion = Mathf.Clamp(velocidadRotacion, 180, 1080);
        
        float paso = velocidadMovimiento * Time.deltaTime;
        
        
        
        if ((transform.position - Player.transform.position).magnitude > EPSILON && transform.position.y < 2)
        {
            gameObject.transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, paso);

        }
        if (transform.position.y <= 1)
        {
            print("Entro rotacion");
            gameObject.transform.Rotate(0f, velocidadRotacion*Time.deltaTime, 0f);
            if (GameManager.Instance.sceneActual == "BoxingHard")
            {
                velocidadRotacion += 60 * Time.deltaTime;
            }
        }

       

    }
}
