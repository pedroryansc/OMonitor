using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logica : MonoBehaviour
{

    public AudioSource som;
    public Image img;

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

}
