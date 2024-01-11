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
        //move projectile
        transform.position += transform.forward * ProjectileSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Enemy"){
            //if projectile touches enemy, destroy itself
            Destroy(this.gameObject);
            //call EnemyScore in PlayerController script
            GameObject.Find("Player").GetComponent<PlayerController>().EnemyScore();
        }else if(collision.gameObject.tag == "Player"){
            //if projectile touches player, do nothing
        }else if(collision.gameObject.tag == "Projectile"){
            //if projectile touches another projectile, do nothing
        }else{
            //if projectile touches anything else, destroy itself
            Destroy(this.gameObject);
        }
    }
}