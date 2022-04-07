using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class CabezaController : MonoBehaviour
{
    float distanciaAObjetivo;
    [SerializeField] GameObject objetivoGO;
    [SerializeField] Vector3 objetivoStartPosition;
    SphereCollider sphereCollider;
    Rig rig;
    float startRadius;
    [SerializeField] float velocidadMovimientCabeza = 2f;
    [SerializeField] float smoothObjetivoMovimiento = 2f;
    bool objetoVisto = false;
    private void Awake() {
        rig = GetComponent<Rig>();
        sphereCollider = GetComponent<SphereCollider>();
        startRadius = sphereCollider.radius;
    }

    private void Update() {
        if(objetoVisto == false){
            objetivoGO.transform.localPosition = objetivoStartPosition;
            rig.weight -= velocidadMovimientCabeza * Time.deltaTime;
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("flood")){
            objetoVisto = true;
            distanciaAObjetivo = Vector3.Distance(other.transform.position, transform.root.position) * 0.65f;
            if(distanciaAObjetivo >= startRadius){
                //Fuera de rango

                sphereCollider.radius = startRadius;
                objetivoGO.transform.position = Vector3.Lerp(objetivoGO.transform.position, objetivoStartPosition, smoothObjetivoMovimiento * Time.fixedDeltaTime);
                rig.weight -= velocidadMovimientCabeza * Time.deltaTime;

            }else{
                //Dentro de rango

                sphereCollider.radius = Vector3.Distance(other.transform.position, transform.root.position) * 0.65f;
                rig.weight += velocidadMovimientCabeza * Time.deltaTime;
                Vector3 moverHacia = new Vector3(other.transform.position.x, other.transform.position.y + 2f, other.transform.position.z);
                objetivoGO.transform.position = Vector3.Lerp(objetivoGO.transform.position, moverHacia, smoothObjetivoMovimiento * Time.fixedDeltaTime);

                //Debug.Log(Vector3.Distance(transform.position, other.transform.position) * 0.65f);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("flood")){
            objetoVisto = false;
        }
    }
    /*
    private void OnDrawGizmos() {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(transform.position, GetComponent<SphereCollider>().radius * 1.5f);
    }
    */
}
