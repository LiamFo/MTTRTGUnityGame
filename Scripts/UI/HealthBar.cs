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
        HealthbarText.text = HealthBarSlider.value.ToString() + " /100";

        if(HealthBarSlider.value == 0){
            Debug.Log("Dead!!!!!!!!");
        }
    }
}
