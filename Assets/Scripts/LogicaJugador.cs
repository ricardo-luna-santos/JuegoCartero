using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaJugador : MonoBehaviour
{
    public int FuerzaSalto;
    public bool EnPiso=false;
    public Rigidbody2D JugadorBody;
    public float Velocidad;
    public bool MirandoDerecha=true;
    public Animator miAnimacion;
    public float reboteEnemigo;
    public float alturaPerdiste;
    public bool Perdiste = false;
    public bool siguienteNivel=false;
    public AudioSource Salto;
    public AudioSource Caida;
    public AudioSource Perder;
    public int zanahoria=0;
    // Start is called before the first frame update
    void Start()
    {
        JugadorBody = GetComponent<Rigidbody2D>();
        miAnimacion=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal=Input.GetAxis("Horizontal");
        ControlarMovimiento(horizontal);
        Voltear(horizontal);
        if(Input.GetKeyDown("space")&&EnPiso)
        {
            Salto.Play();
            miAnimacion.SetFloat("salto",FuerzaSalto);
            JugadorBody.AddForce(new Vector2(0,FuerzaSalto));
        }
        if(gameObject.transform.position.y<alturaPerdiste){
            Perder.Play();
            Perdiste=true;
            JugadorBody.constraints=RigidbodyConstraints2D.FreezeAll;
        }
    }
    private void ControlarMovimiento(float horizontal)
    {
        JugadorBody.velocity=new Vector2(horizontal*Velocidad,JugadorBody.velocity.y);
        miAnimacion.SetFloat("velocidad",Mathf.Abs(horizontal));
    }

    private void onCollisionEnter2D(Collision2D c1){
      /*  if (c1.collider.gameObject.tag == "plataforma"){
           // miAnimacion.SetFloat("salto",0);
        }
       if(c1.collider.gameObject.tag == "zanahoria"){
            zanahoria=zanahoria+1;
            Debug.Log("Zanahoria:"+zanahoria);
        }
        */
        if(c1.collider.gameObject.tag=="enemigo"){

            Debug.Log("Perdiste");
          /*  Perder.Play();
            Perdiste=true;
            JugadorBody.constraints=RigidbodyConstraints2D.FreezeAll;
        */}
    }

    private void Voltear(float horizontal)
    {
    if (EnPiso){
        if(horizontal>0 && !MirandoDerecha || horizontal<0 && MirandoDerecha)
            {
            MirandoDerecha=!MirandoDerecha;
            Vector3 LaEscala=transform.localScale;
            LaEscala.x*=-1;
            transform.localScale=LaEscala;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D c1)
    {
        if(c1.tag=="zanahoria")
        {
            zanahoria=zanahoria+1;
            Debug.Log("Puntos:"+zanahoria);
        }
         if(c1.tag=="enemigo"){
           Perder.Play();
            Perdiste=true;
            JugadorBody.constraints=RigidbodyConstraints2D.FreezeAll;
        }
         if(c1.tag=="siguientenivel"){
           Debug.Log("Ganaste");
           siguienteNivel=true;
            JugadorBody.constraints=RigidbodyConstraints2D.FreezeAll;
        }
    }
}
