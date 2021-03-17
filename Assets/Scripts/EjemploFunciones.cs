using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploFunciones : MonoBehaviour {

    public int variableEntera = 10;


	void Start () {  
        print("Llame start");
        FuncionBasica();
        print("Termino Start");
        FuncionConParametros(999); //Si declaro una funcion con parametro, debo dar un argumento anexada a la funcion
	}
	
	
	void Update () {
		
	}

    void FuncionBasica()  
    {
        print("Llame Funcion Basica");

    }

    void FuncionConParametros(int parametro)  //"parametro" es temporal, es creado cuando se llama la funcion.
    {                                         // Declarar funcion != Llamar funcion
        print("El parametro es: " + parametro);

    }
   
}