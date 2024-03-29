using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyProjectile : MonoBehaviour
{
    
    public float ProjectileSpeed = 100;
    public int DamageValue = 10;
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
        //if projectile touches player, destroy itself
        if(collision.gameObject.tag == "Player"){
            Destroy(this.gameObject);
            //find DealDamage function in PlayerController script and call it
            collision.gameObject.GetComponent<PlayerController>().DealDamage(DamageValue);
        }else if(collision.gameObject.tag == "Enemy"){
            //if projectile touches enemy, do nothing
        }else{
            //if projectile touches anything else, destroy itself
            Destroy(this.gameObject);
        }
    }
}