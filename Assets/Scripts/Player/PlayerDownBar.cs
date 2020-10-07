using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;
using Mirror;

public class PlayerDownBar : NetworkBehaviour
{
    private PlayerMovement pSettings;
    public Image fillImage;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        pSettings = GetComponent<PlayerMovement>();
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

        float fillValue = pSettings.downTime;




        slider.value = fillValue;

    }
}
