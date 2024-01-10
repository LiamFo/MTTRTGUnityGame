using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_BossPlatform : MonoBehaviour
{

    public GameObject BossPlatform;
    public bool MovePlatform = false;
    public AudioSource PlatformMoveSFX;
    public AudioSource PlatformStopSFX;

    // Start is called before the first frame update
    void Start()
    {  

    }

    // Update is called once per frame

    //test
    void Update()
    {
        if(BossPlatform.transform.position.y <= 125){
            MovePlatform = false;
            PlatformMoveSFX.Stop();
        }

        if(MovePlatform == true){
            BossPlatform.transform.Translate(Vector3.down * Time.deltaTime * 4f);
        }
    }

        private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            MovePlatform = true;
            PlatformMoveSFX.Play();
        }

    }
}
