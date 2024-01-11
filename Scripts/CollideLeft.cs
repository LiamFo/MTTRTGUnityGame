using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideLeft : MonoBehaviour
{
    private Rigidbody playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //this is unused code that i ended up scrapping, it was suppose to check collision to your left before i found a better way to do this
     private void OnCollisionEnter(Collision Collision){
        
     }
}
