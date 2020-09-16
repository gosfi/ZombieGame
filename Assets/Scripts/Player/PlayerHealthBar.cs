﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player;

public class PlayerHealthBar : MonoBehaviour
{
    public PlayerMovement pSettings;
    public Image fillImage;
    private Slider slider;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {

        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }

        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }

        UpdateHpBar();

    }


    private void UpdateHpBar()
    {
        float fillValue = pSettings.updateHp;

        if (fillValue <= slider.maxValue / 4)
        {
            fillImage.color = Color.red;
        }
        else if (fillValue <= slider.maxValue / 2)
        {
            fillImage.color = Color.yellow;
        }
        else if (fillValue <= slider.maxValue / 1.3)
        {
            fillImage.color = Color.cyan;
        }
        else
        {
            fillImage.color = Color.white;
        }

        slider.value = fillValue;
    }
}
