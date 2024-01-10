using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_PowerupTut : MonoBehaviour
{

    public Text text;


    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(BounceTutCoroutine("When you have a powerup, you can jump infinitely for a short while"));
            Debug.Log("Trigger touched");
            }
        }
    
    IEnumerator BounceTutCoroutine(string message, float timeToShow = 10){
        //wait for 5 seconds
        yield return new WaitForSecondsRealtime(0.2f);

        // show the text
        text.enabled = true;
        text.text = message;

        //wait for 8 seconds
        yield return new WaitForSecondsRealtime(4.0f);

        // hide the text
        text.enabled = false;
        text.text = "";
    }
}