using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoostBar : MonoBehaviour
{
    Image boostBar;

    public float maxBoost= 100f;
    public static float boost;
    public float descargaBoost;





    void Start()
    {
       
        boostBar = GetComponent<Image>();
        boost = 0f;
      

    }


    void Update()
    { boost = Mathf.Clamp(boost, 0f, maxBoost);

        if (GameManager.Instance.playerBoosted)
        {
            boost -= descargaBoost * Time.deltaTime;
        }

       
        boostBar.fillAmount = boost / maxBoost;
         
    }

}
