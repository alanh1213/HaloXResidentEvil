using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField] Transform _jugador;

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(_jugador);
    }
}
