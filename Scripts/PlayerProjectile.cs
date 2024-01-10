using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProjectile : MonoBehaviour
{
    
    public float ProjectileSpeed = 50;
    public PlayerController player = null;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * ProjectileSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy"){
            Destroy(this.gameObject);
            GameObject.Find("Player").GetComponent<PlayerController>().EnemyScore();
        }else if(collision.gameObject.tag == "Player"){
            //do nothing
        }else if(collision.gameObject.tag == "Projectile"){
            //do nothing
        }else{
            Destroy(this.gameObject);
        }
    }
}