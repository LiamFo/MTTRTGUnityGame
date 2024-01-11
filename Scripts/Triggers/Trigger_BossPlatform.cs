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

        //if platform is at Y125 or lower, stop and play stop SFX
        if(BossPlatform.transform.position.y <= 125){
            MovePlatform = false;
            PlatformMoveSFX.Stop();
        }

        //if MovePlatform is True, move platform down at a constant pase
        if(MovePlatform == true){
            BossPlatform.transform.Translate(Vector3.down * Time.deltaTime * 4f);
        }
    }
        //if player touches triggger, start moving the platform and play the moving SFX
        private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            MovePlatform = true;
            PlatformMoveSFX.Play();
        }

    }
}
