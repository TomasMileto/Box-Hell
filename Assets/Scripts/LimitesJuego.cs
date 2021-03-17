using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitesJuego : MonoBehaviour
{
   

    
   void OnTriggerEnter(Collider other)
    { if (other.tag.Equals("Player"))
        {
            GameManager.Instance.vidaPlayer = 0;
            GameManager.Instance.playerMuerto = true;
        }
        else { }
        Destroy(other.gameObject, 0f);
    }
    }
    
