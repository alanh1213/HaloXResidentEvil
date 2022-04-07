using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PisadaTest : MonoBehaviour
{
    [HideInInspector] public AudioSource audioSource;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Ground")){
            other.GetComponent<SueloController>().AsignarSonidoPisada(audioSource);
            audioSource.Play();
        }
    }
}
