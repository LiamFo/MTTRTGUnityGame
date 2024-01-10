using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_MenuThemeStop : MonoBehaviour
{

    private AudioSource MenuMusic;
    private AudioSource AmbienceMusic;

    public float fadeOutFactor = 1.0f;
     private bool fadeInOut = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AmbienceMusic = GameObject.FindGameObjectWithTag("Ambience").GetComponent<AudioSource>();
        MenuMusic = GameObject.FindGameObjectWithTag("MenuOST").GetComponent<AudioSource>();

        if (fadeInOut == true){
            MenuMusic.volume -= fadeOutFactor;
            AmbienceMusic.volume += fadeOutFactor;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            fadeInOut = true;
            AmbienceMusic.Play();
            AmbienceMusic.volume = 0;

            if(MenuMusic.volume <= 0){
            MenuMusic.Stop();
            }
        }
    }
}