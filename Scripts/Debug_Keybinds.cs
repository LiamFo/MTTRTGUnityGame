using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debug_Keybinds : MonoBehaviour
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
        //pressing these keys will teleport the player to various locations across the game
        //so you dont have to play the entire game when testing small things

        if (Input.GetKeyDown(KeyCode.J)){ //tp to start
            playerRb.transform.position = new Vector3(5, 170, -0.5f);
        }

        if (Input.GetKeyDown(KeyCode.K)){ //tp to gun room
            playerRb.transform.position = new Vector3(111, 127, -0.5f);
        }

        if (Input.GetKeyDown(KeyCode.L)){ //tp to elevator
            playerRb.transform.position = new Vector3(805, 186, -0.5f);
        }

        if (Input.GetKeyDown(KeyCode.M)){ //tp to ice area
            playerRb.transform.position = new Vector3(831, 132, -0.5f);
        }

        if (Input.GetKeyDown(KeyCode.N)){ //tp to boss pit
            playerRb.transform.position = new Vector3(1604, 138, -0.5f);
        }
    }
}
