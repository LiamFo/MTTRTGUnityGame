using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider HealthBarSlider;
    public Text HealthbarText;

    void Start()
    {

    }

    void Update()
    {
        //convert player text to a string value for the slider
        HealthbarText.text = HealthBarSlider.value.ToString() + " /100";

        //debug to check if player is dead
        if(HealthBarSlider.value == 0){
            Debug.Log("Dead!!!!!!!!");
        }
    }
}
