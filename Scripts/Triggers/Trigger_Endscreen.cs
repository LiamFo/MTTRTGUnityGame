using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_Endscreen : MonoBehaviour
{

    public Text text;

    public AudioSource AtmosphereMusic;
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
            AtmosphereMusic.Stop();
            //StartCoroutine(BounceTutCoroutine("The End"));
            }

        }
    
    IEnumerator BounceTutCoroutine(string message, float timeToShow = 10){

        yield return new WaitForSecondsRealtime(1.0f);
            text.enabled = true;
            text.text = message;

        yield return new WaitForSecondsRealtime(4.0f);
            text.text = "Thank You for Playing!";

        yield return new WaitForSecondsRealtime(4.0f);
            text.text = " ";
    }
}
