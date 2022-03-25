using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador_Movimiento : MonoBehaviour
{
    public float velocidadDeRotacion;
    public float velocidadDeMovimiento;
    public bool aiming;
    Animator anim;
    public AudioSource audioSourceZapatillas;
    public GameObject camara;
    [HideInInspector] public float xAxis;
    [HideInInspector] public float zAxis;
    RB2D rb2d;
    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<RB2D>();
    }

    
    void Update()
    {
        
        xAxis = Input.GetAxisRaw("Horizontal");
        zAxis = Input.GetAxisRaw("Vertical");


        if(Input.GetKey(KeyCode.LeftShift))
        {
            velocidadDeMovimiento = 3.5f;
            //audioSourceZapatillas.pitch = 2.4f;
        }else
        {
            velocidadDeMovimiento = 1.5f;
            //audioSourceZapatillas.pitch = 1.5f;
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            //anim.SetTrigger("reload");
        }
        
        if(Input.GetKey(KeyCode.Mouse1))
        {
            aiming = true;
        }else
        {
            aiming = false;
        }
        
        //Movimiento usando Rigidbody
        /*
        if(zAxis != 0 && !aiming)rb2d.SetVelocity(transform.forward * zAxis * velocidadDeMovimiento);
        else rb2d.SetVelocity(Vector3.zero);
        */
        if(zAxis != 0 && !aiming)transform.position += transform.forward * zAxis * velocidadDeMovimiento * Time.deltaTime;
        transform.Rotate(0, xAxis * velocidadDeRotacion * Time.deltaTime, 0, Space.Self);
        
    }

    public void DesactivarPlayer()
    {
        GetComponent<Jugador_Movimiento>().enabled = false;
        //camara.GetComponent<CamaraOrbita>().ActivarDesactivarCamara();
    }

    public void ActivarPlayer()
    {
        GetComponent<Jugador_Movimiento>().enabled = true;
    }
}
