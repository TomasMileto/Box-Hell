using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour {

    

    Text textoVida;
    Image healthBar;
    
    public float maxHealth = 100f;
    public static float health;


   

    
	void Start () {
        healthBar = GetComponent<Image>();
        health = maxHealth;
        textoVida = GetComponentInChildren<Text>();
        
	}
    
	
	void Update ()
    {

        health = GameManager.Instance.vidaPlayer;
        healthBar.fillAmount = health / maxHealth;
        textoVida.text = health.ToString("00") + "/100";
    }
    
}
