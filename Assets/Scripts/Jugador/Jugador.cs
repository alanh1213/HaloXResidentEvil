using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidadDeRotacion;
    public float velocidadDeMovimiento;
    [HideInInspector] public bool aiming;
    [HideInInspector] public Animator anim;
    RB2D rb2d;
    public enum ArmaEstado {Magnum, AR, Nada};
    public ArmaEstado armaEstado;
    Jugador_Ataque jugador_Ataque;
    void Awake()
    {
        rb2d = GetComponent<RB2D>();
        anim = GetComponent<Animator>();
        armaEstado = ArmaEstado.AR;
        jugador_Ataque = GetComponent<Jugador_Ataque>();
    }

    
    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        float shift = Input.GetAxisRaw("Fire3");
        var move = Mathf.Abs(xAxis) + Mathf.Abs(zAxis);
        

        if(Input.GetKey(KeyCode.Mouse1)){
            if(!aiming){
                aiming = true; 
                anim.SetTrigger("click"); 
            }
        }
        else {aiming = false;}


        if(aiming){
            anim.SetBool("aim", true);
            anim.SetFloat("sneaking", 0);
            anim.SetFloat("speed", 0);
        }else{
            anim.SetFloat("sneaking", move);
            
            anim.SetBool("aim", false);

            if(shift != 0){
                velocidadDeMovimiento = 3.5f;
                if(zAxis > 0){
                    transform.position += transform.forward * zAxis * velocidadDeMovimiento * Time.deltaTime;
                    anim.SetFloat("speed", shift);
                }else{
                    transform.position += transform.forward * 0 * velocidadDeMovimiento * Time.deltaTime;
                    anim.SetFloat("speed", 0);
                    anim.SetFloat("sneaking", 0);
                    anim.SetFloat("speed", 0);
                } 
            }else {
                velocidadDeMovimiento = 1.5f;
                anim.SetFloat("speed", 0);

                if(zAxis >= 0){
                    anim.SetFloat("mySpeed", 1f);
                }else{
                    anim.SetFloat("mySpeed", -1f);
                }
                transform.position += transform.forward * zAxis * velocidadDeMovimiento * Time.deltaTime;
            }
            
        }

        transform.Rotate(0, xAxis * velocidadDeRotacion * Time.deltaTime, 0, Space.Self);


        if(Input.GetKeyDown(KeyCode.Alpha1)){armaEstado = ArmaEstado.Nada; jugador_Ataque.EquiparArma();}
        else if (Input.GetKeyDown(KeyCode.Alpha2)){armaEstado = ArmaEstado.Magnum; jugador_Ataque.EquiparArma();}
        else if (Input.GetKeyDown(KeyCode.Alpha3)){armaEstado = ArmaEstado.AR; jugador_Ataque.EquiparArma();};
    }

    public void DesactivarPlayer()
    {
        GetComponent<Jugador>().enabled = false;
    }

    public void ActivarPlayer()
    {
        GetComponent<Jugador>().enabled = true;
    }
}
