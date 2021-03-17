using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Screen : MonoBehaviour {
    Toggle toggle;
    private void Start()
    {
        toggle = GameObject.Find("BoxEvil").GetComponent<Toggle>();
        
    }
    public void GoToScene()
    {
        if (!toggle.isOn)
            SceneManager.LoadScene("Boxing");
        else
            SceneManager.LoadScene("BoxingHard");
        
    }
    public void Quit()
    {
        Application.Quit();
    }
}
