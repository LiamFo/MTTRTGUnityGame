using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject ObjectToDestroy;
    public GameObject Title;

    public GameObject FlashScreen;

    public GameObject ScoreCensor;
    public GameObject HealthCensor;
    public GameObject PlayerCensor;
    // Start is called before the first frame update
    void Start()
    {
        FlashScreen.SetActive(false);   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyGameObject(){
        Destroy(ObjectToDestroy);
        Destroy(Title);
        FlashScreen.SetActive(true);
        Destroy(ScoreCensor);
        Destroy(HealthCensor);
        Destroy(PlayerCensor);
    }
}
