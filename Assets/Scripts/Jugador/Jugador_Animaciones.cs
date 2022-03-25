using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Animaciones : MonoBehaviour
{
    Animator anim;
    public enum Estado {bien, herido, grave, muerto};
    public Estado estadoJugador;
    Jugador_Movimiento jugador_Movimiento;
    AudioSource audioSource_Pisadas;
    void Awake()
    {
        anim = GetComponent<Animator>();
        jugador_Movimiento = GetComponent<Jugador_Movimiento>();
        audioSource_Pisadas = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float zAxis = jugador_Movimiento.zAxis;
        float xAxis = jugador_Movimiento.xAxis;


        if(jugador_Movimiento.aiming)
        {
            anim.SetBool("aim", true);
            if(Input.GetKeyDown(KeyCode.Mouse0))anim.SetTrigger("fire");

        }else anim.SetBool("aim", false);

        if(Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("running", true);
        }else
        {
            anim.SetBool("running", false);
        }

        if(xAxis != 0 && zAxis > 0)
            {
                //SI ESTOY ROTANDO Y MOVIENDO HACIA DELANTE
                anim.SetBool("moving", true);
                anim.SetBool("haciatras", false);
            }else if(xAxis != 0 && zAxis < 0)
            {
                //SI ESTOY ROTANDO Y MOVIENDO HACIA ATRAS
                anim.SetBool("moving", true);
                anim.SetBool("haciatras", true);
            }else if(zAxis > 0)
            {
                //SI SOLAMENTE ESTOY MOVIENDO HACIA DELANTE
                anim.SetBool("moving", true);
            }else if(zAxis < 0)
            {
                //SI SOLAMENTE ESTOY MOVIENDO HACIA ATRAS
                anim.SetBool("moving", true);
                anim.SetBool("haciatras", true);
            }else if(xAxis != 0 && zAxis == 0)
            {
                //SI ESTOY ROTANDO Y NO ME ESTOY MOVIENDO
                anim.SetBool("moving", true);
                anim.SetBool("haciatras", false);
            }else
            {
                //SI NO ESTOY MOVIENDO
                anim.SetBool("moving", false);
                anim.SetBool("haciatras", false);
            }

            SonidoPisadas();
    }

    public void Caminar()
    {
        switch(estadoJugador)
        {
            case Estado.bien:

            break;

            case Estado.herido:

            break;

            case Estado.grave:

            break;
        }
    }

    public void Correr()
    {
        switch(estadoJugador)
        {
            case Estado.bien:

            break;

            case Estado.herido:

            break;

            case Estado.grave:

            break;
        }
    }

    public void Idle()
    {
        switch(estadoJugador)
        {
            case Estado.bien:

            break;

            case Estado.herido:

            break;

            case Estado.grave:

            break;
        }
    }

    public void Golpeada()
    {

    }

    void SonidoPisadas()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.12 || anim.GetCurrentAnimatorStateInfo(0).normalizedTime == 0.25)
            {
                audioSource_Pisadas.PlayOneShot(audioSource_Pisadas.clip);
                Debug.Log("SONIDO PISADA");
            }
        }else if(anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
        {

        }
    }
}
