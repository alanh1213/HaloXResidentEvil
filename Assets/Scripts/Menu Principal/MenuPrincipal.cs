using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuPrincipal : MonoBehaviour
{
    //Controles de botones.
    [SerializeField] private GameObject nuevaPartidaGO, puntuacionGO, salirGO, puntuacion_SalirGO;
    private int botonSeleccionado = 0;
    public bool puntuacionScreen = false;

    //****************************************************************************
    

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(nuevaPartidaGO);
    }
    private void Update()
    {
      if(!puntuacionScreen)
      {
          Controles_Dynpro_MenuPrincipal();
      }else
      {
          Controles_Dynpro_Puntuacion();
      }
    }

    void Controles_Dynpro_MenuPrincipal()
    {
        if(botonSeleccionado == 3) botonSeleccionado = 0;
        else if (botonSeleccionado == -1) botonSeleccionado = 2;

        if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            botonSeleccionado++;
            Static_Sonidos_Menu.Move();

        }else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            botonSeleccionado--;
            Static_Sonidos_Menu.Move();
        }

        switch(botonSeleccionado)
        {
            case 0:
            if(EventSystem.current.currentSelectedGameObject != nuevaPartidaGO) EventSystem.current.SetSelectedGameObject(nuevaPartidaGO);
            break;

            case 1:
            EventSystem.current.SetSelectedGameObject(puntuacionGO);
            break;

            case 2:
            EventSystem.current.SetSelectedGameObject(salirGO);
            break;
        }

    }

    void Controles_Dynpro_Puntuacion()
    {
        if(EventSystem.current.currentSelectedGameObject != puntuacion_SalirGO) EventSystem.current.SetSelectedGameObject(puntuacion_SalirGO);
    }

    public void ActivarDesactivar_PuntucionScreen()
    {
        puntuacionScreen = !puntuacionScreen;
    }
    public void CerrarJuego()
    {
        Application.Quit();
    }

    
}
