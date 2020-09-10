﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCircleRevive : MonoBehaviour
{
    public PlayerSettings pSettings;
    public Transform loadingBar;
    public Transform textLoading;



    // Update is called once per frame
    void Update()
    {
        textLoading.GetComponent<Text>().text = ((int)pSettings.reviveTime * 10).ToString() + "%";
        //textLoading.gameObject.SetActive(true);

        loadingBar.GetComponent<Image>().fillAmount = pSettings.reviveTime / 10;

    }
}
