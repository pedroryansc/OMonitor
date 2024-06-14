using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logica : MonoBehaviour
{

    public AudioSource som;
    public Image img;
    public Text mensagem;
    public float tempo = 0;
    public static Text bestTimesText;

    void Start() {
        bestTimesText = GameObject.Find("BestTimeText").GetComponent<Text>();
        DisplayBestTimes();
    }

    void Update(){

        if(tempo < 7){
            tempo += Time.deltaTime;
        } else if(tempo > 7) {
            mensagem.enabled = false;
        }
        

    }

    public void playGame(){
        SceneManager.LoadScene("Jogo");
    }

    public IEnumerator flashMonitor(){
        for (float i = 0; i <= 0.05f; i += Time.deltaTime){
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
        for (float i = 0.05f; i >= 0; i -= Time.deltaTime){
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }

    public void gameOver(){
        SceneManager.LoadScene("GameOver");
    }

    public void voltarTelaTitulo(){
        SceneManager.LoadScene("TelaTitulo");
    }

    public void fim(){
        float finishTime = Time.time - PlayerMovimento.startTime;
        SaveBestTime(finishTime);
        SceneManager.LoadScene("FimLabirinto");
    }


     public static void SaveBestTime(float newTime)
{
    float[] bestTimes = new float[4];
    for (int i = 0; i < 3; i++)
    {
        bestTimes[i] = PlayerPrefs.GetFloat("BestTime" + (i + 1), float.MaxValue);
    }
    bestTimes[3] = newTime;

    System.Array.Sort(bestTimes);

    for (int i = 0; i < 3; i++)
    {
        PlayerPrefs.SetFloat("BestTime" + (i + 1), bestTimes[i]);
    }

    PlayerPrefs.Save();
}

public static void DisplayBestTimes()
    {
        string bestTimesTextContent = "";
        for (int i = 0; i < 3; i++)
        {
            float bestTime = PlayerPrefs.GetFloat("BestTime" + (i + 1), float.MaxValue);
            if (bestTime < float.MaxValue)
            {
                bestTimesTextContent += (i + 1) + ". " + bestTime.ToString("F2") + " seconds\n";
            }
            else
            {
                bestTimesTextContent += (i + 1) + ". N/A\n";
            }
        }

        bestTimesText.text = bestTimesTextContent;
    }


}
