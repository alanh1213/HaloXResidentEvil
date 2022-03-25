using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private GameObject camara, renderPNG;
    [SerializeField] private bool tieneObjeto;
    private List<GameObject> listaDeCamaras = new List<GameObject>(); 
    void Awake()
    {
        foreach(GameObject objeto in GameObject.FindGameObjectsWithTag("camaras"))
        {
            listaDeCamaras.Add(objeto);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            if(tieneObjeto) renderPNG.layer = LayerMask.NameToLayer("Fondo");   //---> Esto se usa en la prision, en la plataforma, para cambiar el render de objeto a fondo cuando el jugador pisa


            
            foreach(GameObject camara in listaDeCamaras)    //---> Desactivo todas las camaras de la escena
            {
                camara.SetActive(false);
            }

            
            camara.SetActive(true);     //---> Activo la camara vinculada a este script
        }
    }

}
