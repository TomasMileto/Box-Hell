using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayHighScores : MonoBehaviour {
    public Text[] highScoreText;
    static DisplayHighScores Instance;
    LeaderBoardScript highScoreManager;
    UIManagerTitulo UIx;
    private void Awake()
    {
        
        
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        print("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        UIx = FindObjectOfType<UIManagerTitulo>();
        if (UIx!=null)
        {
            for (int i = 0; i < highScoreText.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        highScoreText[i] = UIx.Score1.GetComponent<Text>();
                        break;
                    case 1:
                        highScoreText[i] = UIx.Score2.GetComponent<Text>();
                        break;
                    case 2:
                        highScoreText[i] = UIx.Score3.GetComponent<Text>();
                        break;
                    case 3:
                        highScoreText[i] = UIx.Score4.GetComponent<Text>();
                        break;
                    case 4:
                        highScoreText[i] = UIx.Score5.GetComponent<Text>();
                        break;
                    case 5:
                        highScoreText[i] = UIx.Score6.GetComponent<Text>();
                        break;
                    case 6:
                        highScoreText[i] = UIx.Score7.GetComponent<Text>();
                        break;
                    case 7:
                        highScoreText[i] = UIx.Score8.GetComponent<Text>();
                        break;
                    case 8:
                        highScoreText[i] = UIx.Score9.GetComponent<Text>();
                        break;
                    case 9:
                        highScoreText[i] = UIx.Score10.GetComponent<Text>();
                        break;



                }
            }
        }
    }
        void Start ()
    {
        
        for (int i = 0; i < highScoreText.Length; i++)
        {
            switch (i) {
                case 0:
                    highScoreText[i].text = "I. Buscando...";
                    break;
                case 1:
                    highScoreText[i].text = "II. Buscando...";
                    break;
                case 2:
                    highScoreText[i].text = "III. Buscando...";
                    break;
                case 3:
                    highScoreText[i].text = "IV. Buscando...";
                    break;
                case 4:
                    highScoreText[i].text = "V. Buscando...";
                    break;
                case 5:
                    highScoreText[i].text = "VI. Buscando...";
                    break;
                case 6:
                    highScoreText[i].text = "VII. Buscando...";
                    break;
                case 7:
                    highScoreText[i].text = "VIII. Buscando...";
                    break;
                case 8:
                    highScoreText[i].text = "IX. Buscando...";
                    break;
                case 9:
                    highScoreText[i].text = "X. Buscando...";
                    break;

            }
        }

        highScoreManager = GetComponent<LeaderBoardScript>();
        StartCoroutine("RefreshHighScores");
	}

    public void HighScoresDescargados(HighScore[] highScoreList)
    {
        for (int i = 0; i < highScoreText.Length; i++)
        {
            highScoreText[i].text = "??????";
            if (highScoreList.Length > i)
            {
                switch (i)
                {
                    case 0:
                        highScoreText[i].text = "I. "+ highScoreList[i].username+"      "+ ((int)highScoreList[i].tiempoFinal / 60).ToString("00") + " m  "+ ((int)highScoreList[i].tiempoFinal%60).ToString("00") + " s";
                        break;
                    case 1:
                        highScoreText[i].text = "II. "+ highScoreList[i].username+"      "+ ((int)highScoreList[i].tiempoFinal / 60).ToString("00") + " m  " + ((int)highScoreList[i].tiempoFinal%60).ToString("00") + " s";
                        break;
                    case 2:
                        highScoreText[i].text = "III. " + highScoreList[i].username + "      " + ((int)highScoreList[i].tiempoFinal / 60).ToString("00") + " m  "+ ((int)highScoreList[i].tiempoFinal%60).ToString("00") + " s";
                        break;
                    case 3:
                        highScoreText[i].text = "IV. " + highScoreList[i].username + "      " + ((int)highScoreList[i].tiempoFinal / 60).ToString("00") + " m  "+ ((int)highScoreList[i].tiempoFinal%60).ToString("00") + " s";
                        break;
                    case 4:
                        highScoreText[i].text = "V. " + highScoreList[i].username + "      " + ((int)highScoreList[i].tiempoFinal / 60).ToString("00") + " m  "+ ((int)highScoreList[i].tiempoFinal%60).ToString("00") + " s";
                        break;
                    case 5:
                        highScoreText[i].text = "VI. " + highScoreList[i].username + "      " + ((int)highScoreList[i].tiempoFinal / 60).ToString("00") + " m  "+ ((int)highScoreList[i].tiempoFinal%60).ToString("00") + " s";
                        break;
                    case 6:
                        highScoreText[i].text = "VII. " + highScoreList[i].username + "      " + ((int)highScoreList[i].tiempoFinal / 60).ToString("00") + " m  "+ ((int)highScoreList[i].tiempoFinal%60).ToString("00") + " s"; 
                        break;
                    case 7:
                        highScoreText[i].text = "VIII. "+ highScoreList[i].username+"      "+ ((int)highScoreList[i].tiempoFinal / 60).ToString("00") + " m  "+ ((int)highScoreList[i].tiempoFinal%60).ToString("00") + " s";;
                        break;
                    case 8:
                        highScoreText[i].text = "IX. " + highScoreList[i].username + "      " + ((int)highScoreList[i].tiempoFinal / 60).ToString("00") +" m  "+ ((int)highScoreList[i].tiempoFinal%60).ToString("00") + " s"; 
                        break;
                    case 9:
                        highScoreText[i].text = "X. " + highScoreList[i].username + "      " + ((int)highScoreList[i].tiempoFinal / 60).ToString("00") + " m  "+((int)highScoreList[i].tiempoFinal%60).ToString("00") + " s"; 
                        break;

                }
            }
        }
    }
	IEnumerator RefreshHighScores()
    {
        while (true)
        {
            highScoreManager.DescgargarHighScores();
            yield return new WaitForSeconds(30);
        }
    }
	
}
