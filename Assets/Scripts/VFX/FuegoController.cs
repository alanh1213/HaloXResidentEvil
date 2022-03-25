using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoController : MonoBehaviour
{
    ParticleSystem partSystem;
    [SerializeField] private GameObject parentGO;
    bool active = false;

    private void Awake() {
        partSystem = GetComponent<ParticleSystem>();
    }
    private void Update() {
        if(!parentGO.activeSelf)
        {
            if(active) return;
            partSystem.Play();
            active = true;
        }else
        {
            if(!active) return;
            partSystem.Stop();
            active = false;
        }
    }

    

}
