using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoArmas : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip[] sonidosDisparos;
    SpriteRenderer spriteRenderer;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        StartCoroutine("DesactivarFlash");
        audioSource.clip = sonidosDisparos[Random.Range(0, sonidosDisparos.Length)];
        audioSource.Play();
    }

    IEnumerator DesactivarFlash(){
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = false;
        GetComponent<Light>().enabled = false;
    }
}
