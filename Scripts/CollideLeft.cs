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
     private void OnCollisionEnter(Collision Collision){
        
     }
}
