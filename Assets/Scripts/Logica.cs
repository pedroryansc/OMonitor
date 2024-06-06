using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Logica : MonoBehaviour
{
    
    public void gameOver(){
        SceneManager.LoadScene("GameOver");
    }

}
