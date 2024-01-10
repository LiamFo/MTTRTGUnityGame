using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    public GameObject EnemyProjectile;
    private Rigidbody EnemyRb;
    private Rigidbody PlayerRb;
    public float SeeRange = 30;

    private float Timer = 1.2f;
    private float BulletTime;
    public Transform SpawnManager;
    private Transform target;

    private AudioSource ShootingSFX;
        
    // Start is called before the first frame update
    void Start()
    {
        EnemyRb = GetComponent<Rigidbody>();
        PlayerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

        ShootingSFX = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //if distance between player and enemy is lower than [value], start shooting
            if(Vector3.Distance(PlayerRb.transform.position, EnemyRb.transform.position) <= SeeRange){
                FireProjectile();
            }else if(Vector3.Distance(PlayerRb.transform.position, EnemyRb.transform.position) >= SeeRange){
        }
    }

    private void FireProjectile(){
        BulletTime -= Time.deltaTime;
        if(BulletTime > 0) return;
        BulletTime = Timer;
        
        if(BulletTime > 0){
            ShootingSFX.Play();
        }

        target = PlayerRb.transform;

        GameObject ProjectilePrefab = Instantiate(EnemyProjectile, SpawnManager.transform.position, SpawnManager.transform.rotation) as GameObject;
        ProjectilePrefab.transform.LookAt(PlayerRb.transform.position);
     
    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "PlayerProjectile"){
            Destroy(this.gameObject);
        }
    }
}
