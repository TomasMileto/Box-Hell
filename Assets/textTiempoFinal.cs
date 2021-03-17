using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textTiempoFinal : MonoBehaviour {
    InputField field;
    Text texto;
	void Start () {
        texto = GetComponent<Text>();
	}
	
	void Update () {
        texto.text = "Tiempo final=  " + GameManager.Instance.score + " segundos";
        
	}
}
