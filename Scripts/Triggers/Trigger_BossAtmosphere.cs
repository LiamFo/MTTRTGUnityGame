using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_BossAtmosphere : MonoBehaviour
{

    public AudioSource BossAtmosphere;

    public float fadeOutFactor = 0.0008f;
     private bool fadeInOut = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //fade in music over time
        if (fadeInOut == true){
            BossAtmosphere.volume += fadeOutFactor * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other){
        //if player touches trigger, fade in music
        if(other.gameObject.CompareTag("Player")){
            fadeInOut = true;
            BossAtmosphere.Play();
            Debug.Log("Touched boss atmosphere trigger");
        }
    }
}
