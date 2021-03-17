using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardScript : MonoBehaviour {

    const string privateCode = "FGrGlQQm9kelP8rffs1h4g5tgt3TK4B0GVZwLjbQApJw";
    const string publicCode = "5bc8b886613a89132cf2089a";
    const string webURL = "http://dreamlo.com/lb/";
    public static LeaderBoardScript Instance;

    public HighScore[] highScoresList;
    DisplayHighScores highSchoolDisplay;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(gameObject);
        highSchoolDisplay = FindObjectOfType<DisplayHighScores>().GetComponent<DisplayHighScores>();

        DescgargarHighScores();
    }

    public void AgregarHighScore(string username, int tiempoFinal)
    {
        Instance.StartCoroutine(Instance.SubirHighScore(username, tiempoFinal));
    }

    IEnumerator SubirHighScore(string username, int tiempoFinal)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + tiempoFinal) ;

        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Subido con exito");
            DescgargarHighScores();
        }
        else
        {
            print("Error al subir: " + www.error);
        }
    }

    public void DescgargarHighScores()
    {
        StartCoroutine("DescargarHighScoresWeb");
    }

    IEnumerator DescargarHighScoresWeb()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/0/10");
        yield return www;

        if (string.IsNullOrEmpty(www.error)){
            FormatoHighScore(www.text);
            if (GameManager.Instance.sceneActual == "Titulo")
            {
                highSchoolDisplay.HighScoresDescargados(highScoresList);
            }
        }
        else{
            print("Error al descargar: " + www.error);
        }

    }

    void FormatoHighScore(string texto)
    {
        string[] entradas = texto.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        highScoresList = new HighScore[entradas.Length];
        print(entradas.Length);
        for (int i=0; i<entradas.Length; i++)
        {
            string[] informacionEntrada = entradas[i].Split(new char[] {'|'});
            string username = informacionEntrada[0];
            int tiempoFinal = int.Parse(informacionEntrada[1]);
            highScoresList[i] = new HighScore(username, tiempoFinal);
            print(highScoresList[i].username + ": " + highScoresList[i].tiempoFinal);
        }
    }

    
}

public struct HighScore
{
    public string username;
    public int tiempoFinal;

    public HighScore(string nusername, int ntiempoFinal)
    {
        username = nusername;
        tiempoFinal = ntiempoFinal;

    }
}
