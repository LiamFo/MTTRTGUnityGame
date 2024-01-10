using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{

    
    public float BounceForce = 200;
    // private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        //playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            other.GetComponent<Rigidbody>().AddForce(Vector3.up * BounceForce, ForceMode.Impulse);
            Debug.Log("Touched" + other.gameObject.name);

        }
    }

}
