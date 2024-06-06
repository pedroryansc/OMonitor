using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusSpawner : MonoBehaviour
{

    public GameObject virus;
    public float intervalo = 5;
    private float tempo = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnarVirus();
    }

    // Update is called once per frame
    void Update()
    {
        if(tempo < intervalo)
            tempo += Time.deltaTime;
        else{
            spawnarVirus();
            tempo = 0;
        }
    }

    void spawnarVirus(){
        Instantiate(virus, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }
}
