using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruir : MonoBehaviour
{
    [SerializeField] float tiempo;

    private void Awake() {
        Destroy(gameObject, tiempo);
    }
}
