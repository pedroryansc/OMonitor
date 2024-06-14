using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovimento : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private float vertical;
    private float horizontal;
    public Logica logica;
    public Animator animator;
    public Vector2 teste;
    public Text timeText;

    public static float startTime;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        logica = GameObject.FindGameObjectWithTag("Logica").GetComponent<Logica>();
        timeText = GameObject.Find("TimeText").GetComponent<Text>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        
            vertical = 0.0f;
            horizontal = 0.0f;

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                vertical = 1.0f;
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                vertical = -1.0f;
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                horizontal = -1.0f;
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                horizontal = 1.0f;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                logica.som.Play();
                StartCoroutine(logica.flashMonitor());
                logica.img.color = new Color(0, 0, 0, 0);
            }

            teste = new Vector2(horizontal, vertical);

            animator.SetFloat("vertical", vertical);
            animator.SetFloat("horizontal", horizontal);
            animator.SetFloat("velocity", teste.sqrMagnitude);

            if (teste != Vector2.zero)
            {
                animator.SetFloat("horizontalIdle", horizontal);
                animator.SetFloat("verticalIdle", vertical);
            }

            float currentTime = Time.time - startTime;
            timeText.text = "Timer: " + currentTime.ToString("F2") + " seconds";
        
    }

    void FixedUpdate()
    {
        
            Vector2 position = rigidbody2d.position;

            position.y += 3.7f * vertical * Time.deltaTime;
            position.x += 3.7f * horizontal * Time.deltaTime;

            rigidbody2d.MovePosition(position);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Virus")
        {
            logica.gameOver();
        }
        else if (collision.gameObject.tag == "Fim do Labirinto")
        {
            logica.fim();
        }
    }




}
