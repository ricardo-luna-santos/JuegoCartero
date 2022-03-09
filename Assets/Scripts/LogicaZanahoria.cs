using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaZanahoria : MonoBehaviour
{
    public AudioSource sonido;
    public int puntaje;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D c1)
    {
        if(c1.tag=="Player")
        {
            Destroy(gameObject);
            sonido.Play();
        }
    }
}
