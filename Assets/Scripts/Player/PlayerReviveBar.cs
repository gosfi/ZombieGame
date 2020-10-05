using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;
using Mirror;

public class PlayerReviveBar : NetworkBehaviour
{
    public PlayerMovement pSettings;
    public Image fillImage;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        float fillValue = pSettings.reviveTime;




        slider.value = fillValue;

    }
}
