using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_PickupGun : MonoBehaviour
{

    private AudioSource AudioCombat;
    public Text text;

    private GameObject PlayerGun;
    private GameObject StageGun;

    public PlayerController PlayerScript;
 

    // Start is called before the first frame update

    void Start()
    {
        AudioCombat = GetComponent<AudioSource>();

        PlayerGun = GameObject.FindGameObjectWithTag("Gun_Player");
        StageGun = GameObject.FindGameObjectWithTag("Gun_Cylinder");
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            if(!AudioCombat.isPlaying){
            AudioCombat.Play();
            Destroy(StageGun);
            PlayerScript.PlayerHasGun = true;
            StartCoroutine(ShowMessageCoroutine("MOVE TO THE RIGHT"));
            }
        }
    }
    IEnumerator ShowMessageCoroutine(string message, float timeToShow = 10){
        //wait for 5 seconds
        yield return new WaitForSecondsRealtime(0.4f);

        // show the text
        text.enabled = true;
        text.text = message;

        //wait for 8 seconds
        yield return new WaitForSecondsRealtime(4.4f);

        // hide the text
        text.enabled = false;
        text.text = "";
    }
}