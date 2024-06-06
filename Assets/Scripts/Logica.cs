using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logica : MonoBehaviour
{

    public AudioSource erroGameOver;

    void Start(){
        if(SceneManager.GetActiveScene().name == "GameOver"){
            erroGameOver.Play();
        }
    }

    public void gameOver(){
        SceneManager.LoadScene("GameOver");
    }

    public void restartGame(){
        SceneManager.LoadScene("Jogo");
    }

    public void voltarTelaTitulo(){
        SceneManager.LoadScene("TelaTitulo");
    }

}
