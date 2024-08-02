using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> sounds; 
    public static SoundManager instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;

    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  

    }
   
    

}
