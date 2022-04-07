using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSonidoAmbiental : MonoBehaviour
{
    AudioSource _audioSource;
    [SerializeField] AudioClip[] listaSonidos;

    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }
    private void Update() {
        if(!_audioSource.isPlaying){
            var number = Random.Range(0, listaSonidos.Length);
            _audioSource.clip = listaSonidos[number];
            _audioSource.Play();
        }
    }
}
