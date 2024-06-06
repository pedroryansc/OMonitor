using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusMovimento : MonoBehaviour
{
    private Transform alvo;
    public float velocidade;

    // Start is called before the first frame update
    void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, alvo.position, velocidade * Time.deltaTime);
    }
}
