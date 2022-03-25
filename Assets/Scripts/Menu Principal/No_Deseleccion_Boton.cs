using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class No_Deseleccion_Boton : MonoBehaviour
{
    GameObject lastselect;

    // Update is called once per frame
    void Update () {         
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            EventSystem.current.SetSelectedGameObject(lastselect);
        }
        else
        {
            lastselect = EventSystem.current.currentSelectedGameObject;
        }

        Debug.Log("lastselect: " + lastselect);
        Debug.Log("eventsystem current: " + EventSystem.current.currentSelectedGameObject);
    }
}
