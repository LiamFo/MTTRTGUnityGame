using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier = 1;
    public float HorizontalInput;
    public float MoveSpeed = 100;
    public float Magnitude = 100;

    public bool IsOnGround = true;
    public bool hasPowerup;
    public GameObject PowerupIndicator;
    public float maxSpeed = 20;

    public Slider HealthBarSlider;
    private int Health = 100;

    public GameObject FlashImg;

    public int HealthKitValue = 20;
    public Text ScoreText;

    public int ScoreTextValue = 0;
    public GameObject PlSpawnManager;
    public GameObject PlProjectile;
    public AudioSource ShootingSFX;
    public AudioSource PlayerDeathSFX;
    public AudioSource PlayerHitSFX;
    public bool PlayerHasGun = false;
    



    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        HorizontalInput = Input.GetAxis("Horizontal");

        ScoreTextValue = 0;
        ScoreText.text = ScoreTextValue.ToString();

        ShootingSFX = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)){
            if(PlayerHasGun == true){
            PlayerFireProjectile();
            }
        }

        if(HealthBarSlider.value < 0){
            HealthBarSlider.value = 0;
        }

        if(HealthBarSlider.value <= 0){
            DeathState();
        }

        HealthBarSlider.value = Health;

        if(FlashImg != null){
            if(FlashImg.GetComponent<Image>().color.a > 0){
                var color = FlashImg.GetComponent<Image>().color;
                color.a -= 0.01f;
                FlashImg.GetComponent<Image>().color = color;
            }
        }

            if(Input.GetKeyDown(KeyCode.Space) && IsOnGround){
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                if(hasPowerup ==false){
                    IsOnGround = false;
                }
            }
            
         if (Input.GetKey(KeyCode.A)){
            playerRb.AddForce(Vector3.left * MoveSpeed);
         }

        if (Input.GetKey(KeyCode.D)){
            playerRb.AddForce(Vector3.right * MoveSpeed);
         }

        if(GetComponent<Rigidbody>().velocity.magnitude > maxSpeed){
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
        }
    }

    private void OnCollisionEnter(Collision Collision){
        if(Collision.gameObject.tag == "Ground"){
            IsOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Powerup")){
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            PowerupIndicator.gameObject.SetActive(true);

        }
            if(other.CompareTag("HealthPickUp")){
            if(Health < 100){
            Health += HealthKitValue;
            Destroy(other.gameObject);
            ScoreTextValue += 25;
            ScoreText.text = ScoreTextValue.ToString();
                }
                if(Health >= 101){
                Health = 100;
            }
            }



            IEnumerator PowerupCountdownRoutine(){
            yield return new WaitForSeconds(8);
            hasPowerup = false;
            PowerupIndicator.gameObject.SetActive(false);
            }
        }
    


        public void DealDamage(int DamageValue){
            Health -= DamageValue;
            ScoreTextValue -= 15;
            if(ScoreTextValue < 0){
                ScoreTextValue = 0;
            }
            ScoreText.text = ScoreTextValue.ToString();
            FlashScreenAppear();
            PlayerHitSFX.Play();
        }

        public void DeathState(){
            PlayerDeathSFX.Play();
            playerRb.transform.position = new Vector3(250, 300, -0.5f);
            PlayerHasGun = false;
        }

        public void EnemyScore(){
            ScoreTextValue += 100;
            ScoreText.text = ScoreTextValue.ToString();
        }

        private void FlashScreenAppear(){
            var color = FlashImg.GetComponent<Image>().color;
            color.a = 0.8f;

            FlashImg.GetComponent<Image>().color = color;
        }

        private void PlayerFireProjectile(){
            //Debug.Log("Player Shoots");
            ShootingSFX.Play();

            var MousePos = Input.mousePosition;
            MousePos.z = -0.5f; 

            Vector3 PLEASEWORK = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PLEASEWORK = PLEASEWORK + transform.position;
            PLEASEWORK.z = transform.position.z;

            GameObject PlayerProjectilePrefab = Instantiate(PlProjectile, PlSpawnManager.transform.position, PlSpawnManager.transform.rotation) as GameObject;
            PlayerProjectilePrefab.transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15.0f)));


            //Debug.Log(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z)));

     
    }
}
