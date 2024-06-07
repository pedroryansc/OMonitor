using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimento : MonoBehaviour
{

    Rigidbody2D rigidbody2d;
    float vertical;
    float horizontal;
    public Logica logica;

    // Start is called before the first frame update
    void Start()
    {
        // QualitySettings.vSyncCount = 0;
        // Application.targetFrameRate = 60;
        rigidbody2d = GetComponent<Rigidbody2D>();
        logica = GameObject.FindGameObjectWithTag("Logica").GetComponent<Logica>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = 0.0f;
        horizontal = 0.0f;
        
        if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)){
            vertical = 1.0f;
        } else if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)){
            vertical = -1.0f;
        }

        // Debug.Log(vertical);

        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
            horizontal = -1.0f;
        } else if(Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)){
            horizontal = 1.0f;
        }

        // Debug.Log(horizontal);

        if(Input.GetKey(KeyCode.Space)){
            logica.som.Play();
        }
    }

    void FixedUpdate(){
        Vector2 position = rigidbody2d.position;

        position.y = position.y + 3.7f * vertical * Time.deltaTime;
        position.x = position.x + 3.7f * horizontal * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.tag == "Virus"){
            logica.gameOver();
        }
    }
}
