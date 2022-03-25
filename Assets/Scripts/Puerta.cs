using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puerta : MonoBehaviour
{
    private enum niveles {Prision, Pasillos, Balcon, Plataformas};
    [SerializeField] private niveles cargarNivel; 
    bool _enPuerta;

    private void Start() {
        _enPuerta = false;
    }

    private void Update() {
        if(_enPuerta && Input.GetKeyDown(KeyCode.Space)){
            //Si el jugador esta dentro del rango del trigger y aprieta enter
            Debug.Log("Cargar escena...");
            SceneManager.LoadSceneAsync(ObtenerEscena(cargarNivel), LoadSceneMode.Single);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player")) _enPuerta = true;
    }

    void OnTriggerExit(Collider other)
    {
        if(other.transform.CompareTag("Player")) _enPuerta = false;
    }

    IEnumerator LoadYourAsyncScene(GameObject player)
    {
        // Set the current Scene to be able to unload it later
        Scene currentScene = SceneManager.GetActiveScene();

        // The Application loads the Scene in the background at the same time as the current Scene.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(ObtenerEscena(cargarNivel), LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        // Move the GameObject (you attach this in the Inspector) to the newly loaded Scene
        SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByBuildIndex(ObtenerEscena(cargarNivel)));
        // Unload the previous Scene
        SceneManager.UnloadSceneAsync(currentScene);
    }

    private int ObtenerEscena(niveles nivel)
    {
        int nivelACargar = 0;
        switch(nivel)
        {
            case niveles.Prision:
            nivelACargar = 0;
            break;

            case niveles.Pasillos:
            nivelACargar = 1;
            break;

            case niveles.Balcon:
            nivelACargar = 2;
            break;

            case niveles.Plataformas:
            nivelACargar = 3;
            break;
        } 

        return nivelACargar;
    }
}
