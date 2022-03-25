using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Static_Sonidos_Menu : MonoBehaviour
{
    [SerializeField] private AudioClip sonido_Select, sonido_Cancel, sonido_Move;
    static AudioClip st_sonido_Select, st_sonido_Cancel, st_sonido_Move;
    static AudioSource audioSource;

    private void Awake() 
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        st_sonido_Select = sonido_Select;
        st_sonido_Cancel = sonido_Cancel;
        st_sonido_Move = sonido_Move;
    }

    public static void Select()
    {
        audioSource.clip = st_sonido_Select;
        audioSource.Play();
    }

    public static void Move()
    {
        audioSource.clip = st_sonido_Move;
        audioSource.Play();
    }

    public static void Cancel()
    {
        audioSource.clip = st_sonido_Cancel;
        audioSource.Play();
    }
}
