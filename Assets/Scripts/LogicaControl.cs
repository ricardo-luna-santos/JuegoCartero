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
        TextodelJuego.text="Nivel: "+(indicenivel+1)+"\nPuntaje: "+Jugador.zanahoria;
        if(Jugador.Perdiste){
            TextodelJuego.text="Nivel"+(indicenivel+1)+"\nPuntaje "+
            Jugador.zanahoria+"\nPerdiste"+"\nPulsa R para continuar";
            if(Input.GetKeyDown("r")){
                Jugador.zanahoria=0;
                Jugador.JugadorBody.constraints=RigidbodyConstraints2D.None;
                Jugador.JugadorBody.constraints=RigidbodyConstraints2D.FreezeRotation;
                Jugador.gameObject.transform.position=PuntoInicio.transform.position;
                Destroy(ObjetoNivel);
                ObjetoNivel=Instantiate(NivelPreFab[indicenivel]);
                ObjetoNivel.transform.SetParent(this.transform);
                Jugador.Perdiste=false;
             //   TextodelJuego.text="Nivel: "+(indicenivel+1)+"\nPuntaje: "+Jugador.zanahoria;
            }
        }else if(Jugador.siguienteNivel && Jugador.zanahoria==15){
            
            TextodelJuego.text="Nivel"+(indicenivel+1)+"\nPuntaje "+
            Jugador.zanahoria+"\nCompletaste el nivel"+"\nPulsa R para avanzar";
            if(indicenivel==NivelPreFab.Length-1){
            TextodelJuego.text="Juego Terminado\nPulsa R para reiniciar el juego";
            if(Input.GetKeyDown("r")){
                Jugador.zanahoria=0;
                Jugador.JugadorBody.constraints=RigidbodyConstraints2D.None;
                Jugador.JugadorBody.constraints=RigidbodyConstraints2D.FreezeRotation;
                Jugador.gameObject.transform.position=PuntoInicio.transform.position;
                Destroy(ObjetoNivel);
                indicenivel=0;
                ObjetoNivel=Instantiate(NivelPreFab[indicenivel]);
                ObjetoNivel.transform.SetParent(this.transform);
                Jugador.siguienteNivel=false;
            }
        }else if(Input.GetKeyDown("r")){
                Jugador.zanahoria=0;
                Jugador.JugadorBody.constraints=RigidbodyConstraints2D.None;
                Jugador.JugadorBody.constraints=RigidbodyConstraints2D.FreezeRotation;
                Jugador.gameObject.transform.position=PuntoInicio.transform.position;
                Destroy(ObjetoNivel);
                indicenivel+=1;
                ObjetoNivel=Instantiate(NivelPreFab[indicenivel]);
                ObjetoNivel.transform.SetParent(this.transform);
                Jugador.siguienteNivel=false;
            }
        }else{
            TextodelJuego.text="Nivel"+(indicenivel+1)+"\nPuntaje "+
            Jugador.zanahoria+"\nTe falta completar "+(15-Jugador.zanahoria)+" puntos\npara pasar el nivel";
        }
    }
}
