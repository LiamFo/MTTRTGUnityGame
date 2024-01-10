using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Trigger_DeathState : MonoBehaviour
{

    public AudioSource AudioCombat;

    public GameObject Score;
    public GameObject Health;
    public GameObject ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        AudioCombat = GameObject.FindGameObjectWithTag("GunStage").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

        private void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            AudioCombat.Stop();
            HideMenu();
            }
        }

        public void HideMenu(){
        Destroy(Health);
        Destroy(Score);
        Destroy(ScoreText);
    }
}
