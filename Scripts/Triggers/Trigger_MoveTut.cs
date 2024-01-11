using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_MoveTut : MonoBehaviour
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

    //if player touches trigger, explain how to move sideways
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            //start timer
            StartCoroutine(MoveTutCoroutine("Press A / D to move"));
            Debug.Log("Trigger touched");
            }
        }
    
    //activate text
    IEnumerator MoveTutCoroutine(string message, float timeToShow = 10){
        //wait for 5 seconds
        yield return new WaitForSecondsRealtime(1.0f);

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