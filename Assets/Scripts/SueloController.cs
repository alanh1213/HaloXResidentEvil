using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloController : MonoBehaviour
{
    [SerializeField] AudioClip[] listaSonidos;

    public void AsignarSonidoPisada(AudioSource audioSource){
        audioSource.clip = listaSonidos[Random.Range(0, listaSonidos.Length)];
    }
}
