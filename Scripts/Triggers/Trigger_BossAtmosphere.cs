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
        //BossAtmosphere = GameObject.FindGameObjectWithTag("Boss_Atmosphere").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (fadeInOut == true){
            BossAtmosphere.volume += fadeOutFactor * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            fadeInOut = true;
            BossAtmosphere.Play();
            Debug.Log("Touched boss atmosphere trigger");
        }
    }
}
