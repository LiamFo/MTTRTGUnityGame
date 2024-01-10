using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioThing : MonoBehaviour
{

    private AudioSource AudioTest;
    // Start is called before the first frame update

    void Start()
    {
        AudioTest = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(!AudioTest.isPlaying){
            AudioTest.Play();
            }
        }
    }
}
