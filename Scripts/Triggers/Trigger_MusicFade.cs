using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_MusicFade : MonoBehaviour
{

    private AudioSource StageMusic;

    public float fadeOutFactor = 0.0008f;
     private bool fadeInOut = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StageMusic = GameObject.FindGameObjectWithTag("GunStage_Music_Trigger").GetComponent<AudioSource>();

        if (fadeInOut == true){
            StageMusic.volume -= fadeOutFactor * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            fadeInOut = true;
            Debug.Log("Touched music fade trigger");

            if(StageMusic.volume <= 0){
            StageMusic.Stop();
            }
        }
    }
}
