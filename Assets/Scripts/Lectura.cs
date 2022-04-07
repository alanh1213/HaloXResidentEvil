using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lectura : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    [SerializeField] private string[] sentences;
    private int index;
    private float velocidad = 0.15f;
    private bool _enTexto = false;
    private bool _escribiendo = false;
    Collider other;

    private void Awake()
    {
        textDisplay = GameObject.FindGameObjectWithTag("Canvas").transform.Find("Mensaje").transform.GetComponent<TextMeshProUGUI>();
    }

    private void Update() 
    {
        if(_escribiendo)
        {
            if(Input.GetAxis("Jump") != 0)
            {
                velocidad = 0.01f;
            }else
            {
                velocidad = 0.15f;
            }
        }

        if(_enTexto && !_escribiendo && Input.GetKeyDown(KeyCode.Space))
        {
            SiguienteOracion(other);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            this.other = other;   
        }
    }
    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space) && !_enTexto)
        {
            index = 0; //---> Resetea el index asi puede volver a leerse
            other.GetComponent<Jugador>().enabled = false;
            StartCoroutine("Escribir");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            textDisplay.text = "";
            _enTexto = false;
        }
    }

    IEnumerator Escribir()
    {
        textDisplay.text = "";
        _enTexto = true;
        Debug.Log("ESCRIBIR2");
        _escribiendo = true;
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(velocidad);
        }
        _escribiendo = false;
    }

    public void SiguienteOracion(Collider other)
    {
        if(index < sentences.Length - 1)  //---> Si todavia no se llego a la oracion final, pasamos a la siguiente
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Escribir());
        }else                             //---> Si llegamos a la oracion final, le devolvemos el control al jugador
        {
            textDisplay.text = "";
            _enTexto = false;
            other.GetComponent<Jugador>().enabled = true;
        }
    }
}
