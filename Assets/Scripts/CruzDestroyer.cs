using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CruzDestroyer : MonoBehaviour {
    string cruzColor;

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter(Collider other)
    {   cruzColor = this.gameObject.name;
        DestruirCruz(cruzColor, other.gameObject.name);
    }

    void DestruirCruz (string n, string m)
    {
        switch (n)
        {
            case "CruzNegra(Clone)":
                if (m == "Enemigo1(Clone)" || m=="Enemigo1.Hard(Clone)")
                    Destroy(this.gameObject);
                break;
            case "CruzAmarilla(Clone)":
                if (m == "Enemigo2(Clone)" || m == "Enemigo2.Hard(Clone)")
                    Destroy(this.gameObject);
                break;
            case "CruzVerde(Clone)":
                if (m == "Enemigo3(Clone)" || m == "Enemigo3.Hard(Clone)")
                    Destroy(this.gameObject);
                break;

        }
    }

}