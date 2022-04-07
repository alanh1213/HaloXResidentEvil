using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationReset : MonoBehaviour
{
    Quaternion _startRot;
    private void Awake() {
        _startRot = transform.rotation;
    }
    void Update()
    {
        if(transform.eulerAngles.x > 5){
            Debug.Log("SIIIIIIIIIUUUUUUUUUUUUUU");
            //transform.rotation = _startRot;
        }
    }
}
