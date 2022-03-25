using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    Transform jugador;
    void Start()
    {
        jugador = GameObject.Find("Jugador").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(jugador);
    }
}
