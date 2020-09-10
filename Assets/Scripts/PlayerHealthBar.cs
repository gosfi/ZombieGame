using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerSettings pSettings;
    public Image fillImage;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {

        if(slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if(slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        
        float fillValue = pSettings.updateHp;

        if(fillValue <= slider.maxValue / 4)
        {
            fillImage.color = Color.red;
        }
        else if(fillValue <= slider.maxValue / 2)
        {
            fillImage.color = Color.yellow;
        }
        else if (fillValue <= slider.maxValue / 1.3)
        {
            fillImage.color = Color.cyan;
        }
        else if(fillValue > slider.maxValue / 4 && fillValue > slider.maxValue / 2 && fillValue > slider.maxValue / 1.5)
        {
            fillImage.color = Color.white;
        }

        slider.value = fillValue;
    }
}
