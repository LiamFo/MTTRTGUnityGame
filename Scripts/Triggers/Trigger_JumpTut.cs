using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_JumpTut : MonoBehaviour
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

    //if player touches trigger, explain how to jump
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            //start timer
            StartCoroutine(JumpTutCoroutine("Press space to jump"));
            Debug.Log("Trigger touched");
            }
        }
    
    //activate text
    IEnumerator JumpTutCoroutine(string message, float timeToShow = 10){
        //wait for 5 seconds
        yield return new WaitForSecondsRealtime(0.7f);

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
