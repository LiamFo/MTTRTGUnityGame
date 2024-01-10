using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_BuildStop : MonoBehaviour
{

    private AudioSource StageMusic;
    private AudioSource AmbienceMusic;

    public float fadeOutFactor = 0.08f;
     private bool fadeInOut = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StageMusic = GameObject.FindGameObjectWithTag("GunStage").GetComponent<AudioSource>();
        AmbienceMusic = GameObject.FindGameObjectWithTag("Ambience").GetComponent<AudioSource>();

        if (fadeInOut == true){
            StageMusic.volume -= fadeOutFactor;
            AmbienceMusic.volume -= fadeOutFactor;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            fadeInOut = true;
            AmbienceMusic.Stop();

            if(StageMusic.volume <= 0){
            StageMusic.Stop();
            }
        }
    }
}
