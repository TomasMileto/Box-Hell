using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererOff : MonoBehaviour {
    Renderer renderazo;
    Missile missile;
    
    
	void Start () {
        renderazo = this.gameObject.GetComponent<Renderer>();
        missile = GetComponentInParent<Missile>();

	}
	
	void Update ()
    {
        if (missile != null)
        {
            if (missile.exploded)
            {
                renderazo.enabled = false;
            }
        }
	}
}
