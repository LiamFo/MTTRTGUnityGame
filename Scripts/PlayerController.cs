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
        //get player rigidbody component

        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        HorizontalInput = Input.GetAxis("Horizontal");

        ScoreTextValue = 0;
        //converts scoretext into a value that also gets converted into a string
        ScoreText.text = ScoreTextValue.ToString();

        ShootingSFX = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        //if player presses mouse1 and player has grabbed the gun, call PlayerFireProjectile
        if (Input.GetMouseButtonDown(0)){
            if(PlayerHasGun == true){
            PlayerFireProjectile();
            }
        }

        //if health is below 0, set back to 0
        if(HealthBarSlider.value < 0){
            HealthBarSlider.value = 0;
        }

        //if health is 0, call DeathState
        if(HealthBarSlider.value <= 0){
            DeathState();
        }

        HealthBarSlider.value = Health;


        //Activates damage flash (screen flashes red when taking damage), this part slowly changes the alpha of the image
        if(FlashImg != null){
            if(FlashImg.GetComponent<Image>().color.a > 0){
                var color = FlashImg.GetComponent<Image>().color;
                color.a -= 0.01f;
                FlashImg.GetComponent<Image>().color = color;
            }
        }

        //if player presses spacebar and is on the ground, apply vertical force
        //if player has a powerup, allow player to jump multiple times
            if(Input.GetKeyDown(KeyCode.Space) && IsOnGround){
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                if(hasPowerup ==false){
                    IsOnGround = false;
                }
            }
            
        //if player presses A, apply force pushing them to the left
         if (Input.GetKey(KeyCode.A)){
            playerRb.AddForce(Vector3.left * MoveSpeed);
         }

        //if player presses D, apply force pushing them to the right
        if (Input.GetKey(KeyCode.D)){
            playerRb.AddForce(Vector3.right * MoveSpeed);
         }

        //if player magnitude is higher than the speed, normalize the speed
        //this limits the player speed
        if(GetComponent<Rigidbody>().velocity.magnitude > maxSpeed){
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxSpeed;
        }
    }


    //if the player touches an object tagged as "ground", set IsOnGround to True, allowing the player to jump again
    private void OnCollisionEnter(Collision Collision){
        if(Collision.gameObject.tag == "Ground"){
            IsOnGround = true;
        }
    }

    private void OnTriggerEnter(Collider other){
        //if player touches object tagged as "Powerup", activate functions
        if(other.CompareTag("Powerup")){
            hasPowerup = true;
            //destroy powerup
            Destroy(other.gameObject);
            //start timer
            StartCoroutine(PowerupCountdownRoutine());
            //make powerup indicator appear, showing that the powerup is active
            PowerupIndicator.gameObject.SetActive(true);

        }
        //if player touches object tagged as "HealthPickUp", activate functions
            if(other.CompareTag("HealthPickUp")){
            //if health is below 100, pickup healthpickup and add 25 to the healthbar and destroy itself
            if(Health < 100){
            Health += HealthKitValue;
            Destroy(other.gameObject);
            ScoreTextValue += 25;
            ScoreText.text = ScoreTextValue.ToString();
                }
            //if health is 101 or higher, set to 100
                if(Health >= 101){
                Health = 100;
            }
            }


        //powerup countdown
            IEnumerator PowerupCountdownRoutine(){
            //wait 8 seconds before setting hasPowerup to False and hiding the powerupindicator
            yield return new WaitForSeconds(8);
            hasPowerup = false;
            PowerupIndicator.gameObject.SetActive(false);
            }
        }
    


        //deal damage to the player, subtracting a value from the healthbar
        public void DealDamage(int DamageValue){
            //subtract 25 health from the player's hp
            Health -= DamageValue;
            ScoreTextValue -= 15;
            if(ScoreTextValue < 0){
                ScoreTextValue = 0;
            }
            ScoreText.text = ScoreTextValue.ToString();
            //call FlashScreenAppear
            FlashScreenAppear();
            PlayerHitSFX.Play();
        }

        //teleport player to a box outside the map, play death sound effect and disable shooting
        public void DeathState(){
            PlayerDeathSFX.Play();
            playerRb.transform.position = new Vector3(250, 300, -0.5f);
            PlayerHasGun = false;
        }

        //add 100 points to the score
        public void EnemyScore(){
            ScoreTextValue += 100;
            ScoreText.text = ScoreTextValue.ToString();
        }

        //Make red image (that covers the screen) slowly appear by raising the alpha
        private void FlashScreenAppear(){
            var color = FlashImg.GetComponent<Image>().color;
            color.a = 0.8f;

            FlashImg.GetComponent<Image>().color = color;
        }

        //functions player shooting
        private void PlayerFireProjectile(){
            
            ShootingSFX.Play();

            var MousePos = Input.mousePosition;
            MousePos.z = -0.5f; 

            //convert mouse position of screen to world coordinates
            Vector3 PLEASEWORK = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PLEASEWORK = PLEASEWORK + transform.position;
            PLEASEWORK.z = transform.position.z;


            //spawn player projectile at player spawnmanager
            GameObject PlayerProjectilePrefab = Instantiate(PlProjectile, PlSpawnManager.transform.position, PlSpawnManager.transform.rotation) as GameObject;

            //aim player projectile at user's mouse position
            PlayerProjectilePrefab.transform.LookAt(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 15.0f)));

     
    }
}
