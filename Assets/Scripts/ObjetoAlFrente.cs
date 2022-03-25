using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoAlFrente : MonoBehaviour
{
    [SerializeField] private GameObject renderGO;
    [SerializeField] private bool invertir = false;

    private void OnTriggerStay(Collider other) 
    {
        if(!invertir)
        {
            if(other.tag == "Player")
            {
                renderGO.layer = LayerMask.NameToLayer("Fondo");
            }
        }else
        {
            if(other.tag == "Player")
            {
                renderGO.layer = LayerMask.NameToLayer("ObjetosDinamicos");
            }
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(!invertir)
        {
            if(other.tag == "Player")
            {
                renderGO.layer = LayerMask.NameToLayer("ObjetosDinamicos");
            }
        }else
        {
            if(other.tag == "Player")
            {
                renderGO.layer = LayerMask.NameToLayer("Fondo");
            }
        }
    }
}
