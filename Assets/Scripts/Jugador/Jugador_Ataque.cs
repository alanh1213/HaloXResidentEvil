using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Jugador_Ataque : MonoBehaviour
{
    [SerializeField] GameObject _arFlashGO, _magnumFlashGO;
    [SerializeField] Transform _arFlashPO, _magnumFlashPO;
    [SerializeField] float magnumTimeBtwBullets = 1f;
    [SerializeField] float arTimeBtwBullets = 0.2f;
    [SerializeField] GameObject rifleAsaltoGO, magnumGO;
    float startMagnumTimeBtwBullets;
    float startArTimeBtwBullets, _nextBullet;
    [SerializeField] Camera camara;
    Jugador jugador;
    [SerializeField] ParticleSystem casquilloParticleSystem;

    private void Awake() {
        jugador = GetComponent<Jugador>();
        startMagnumTimeBtwBullets = magnumTimeBtwBullets;
        startArTimeBtwBullets = arTimeBtwBullets;
        _nextBullet = 0f;
    }


    private void Update() {
        jugador.anim.ResetTrigger("fire");
        switch (jugador.armaEstado){
            case Jugador.ArmaEstado.Nada:


            break;

            case Jugador.ArmaEstado.Magnum:
                if(jugador.aiming && Input.GetKeyDown(KeyCode.Mouse0)){
                    if(_nextBullet < Time.time){
                        _nextBullet = Time.time + magnumTimeBtwBullets;
                        jugador.anim.SetTrigger("fire");
                        var flash = Instantiate(_magnumFlashGO, _magnumFlashPO.position, Quaternion.identity);
                        camara = GameObject.FindGameObjectWithTag("camaras").GetComponent<Camera>();
                        flash.transform.LookAt(camara.transform.position);
                        flash.transform.rotation = Quaternion.Euler(flash.transform.rotation.x, flash.transform.rotation.y, Random.Range(-90, 90));

                        float numRandom = Random.Range(0.5f, 1f);
                        flash.transform.localScale = new Vector3(numRandom, numRandom, 1);
                        flash.transform.parent = magnumGO.transform;
                    }
                }

            break;

            case Jugador.ArmaEstado.AR:
                if(jugador.aiming && Input.GetKey(KeyCode.Mouse0)){
                    if(_nextBullet < Time.time){
                        _nextBullet = Time.time + arTimeBtwBullets;
                        jugador.anim.SetTrigger("fire");
                        GameObject flash = Instantiate(_arFlashGO, _arFlashPO.position, Quaternion.identity);
                        flash.transform.rotation = transform.rotation;
                        flash.transform.Rotate(0,0, Random.Range(-90, 90), Space.Self);            
                        float numRandom = Random.Range(0.5f, 1f);
                        flash.transform.localScale = new Vector3(numRandom, numRandom, 1);
                        flash.transform.parent = rifleAsaltoGO.transform;
                        casquilloParticleSystem.Emit(count: 1);
                        casquilloParticleSystem.gameObject.transform.Rotate(Random.Range(-5f, 5f), 0, 0, Space.Self);
                    }
                }
            break;
        }
    }

    public void EquiparArma()
    {
        switch (jugador.armaEstado){
            case Jugador.ArmaEstado.Nada:
                jugador.anim.SetLayerWeight(1, 0);
                rifleAsaltoGO.SetActive(false);
                magnumGO.SetActive(false);
                Debug.Log("Armas desequipadas");
            break;

            case Jugador.ArmaEstado.Magnum:
                rifleAsaltoGO.SetActive(false);
                magnumGO.SetActive(true);
                jugador.anim.SetLayerWeight(1, 0);
                Debug.Log("Magnum equipada");
            break;

            case Jugador.ArmaEstado.AR:
                rifleAsaltoGO.SetActive(true);
                magnumGO.SetActive(false);
                jugador.anim.SetLayerWeight(1, 1);
                Debug.Log("AR equipado");
            break;
        }
    }

}
