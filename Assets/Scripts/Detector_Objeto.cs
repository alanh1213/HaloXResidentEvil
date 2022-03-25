using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_Objeto : MonoBehaviour
{
    /*
        Este script es igual al Detector salvo que no incluye la camara, osea que solo cambia los layers del render de Fondo --> ObjetoDinamico o 
        viceversa.
    */

    [SerializeField] GameObject renderPNG;
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player" && renderPNG.layer != LayerMask.GetMask("ObjetosDinamicos"))
        {
            renderPNG.layer = LayerMask.NameToLayer("ObjetosDinamicos");
        {
            return;
        }
    }
    
    }
}
