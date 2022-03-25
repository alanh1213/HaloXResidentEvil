using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma_Seleccion : MonoBehaviour
{
    //********************************************************
    //Este script controla la rotacion de la plataforma en la pantalla de seleccion
    //********************************************************
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            //Rotar plataforma a la derecha
            anim.SetTrigger("derecha");
        }else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Rotar plataforma a la izquierda
            anim.SetTrigger("izquierda");
        }
    }
}
