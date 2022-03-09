using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaControl : MonoBehaviour
{
    public AudioSource Musica;
    public LogicaJugador Jugador;
    public GameObject PuntoInicio;
    public GameObject[] NivelPreFab;
    private int indicenivel;
    private GameObject ObjetoNivel;
    private GameObject Moneda;
    public int Puntaje;
    public Text TextodelJuego;
    public bool Escucho=false;
    // Start is called before the first frame update
    void Start()
    {
        ObjetoNivel=Instantiate(NivelPreFab[indicenivel]);
        ObjetoNivel.transform.SetParent(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
