using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logica : MonoBehaviour
{

    public AudioSource som;

    public void playGame(){
        SceneManager.LoadScene("Jogo");
    }

    public void gameOver(){
        SceneManager.LoadScene("GameOver");
    }

    public void voltarTelaTitulo(){
        SceneManager.LoadScene("TelaTitulo");
    }

}
