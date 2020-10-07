using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class PlayerCircleRevive : NetworkBehaviour
{
    private PlayerMovement pSettings;
    public Transform loadingBar;
    public Transform textLoading;


    private void Start()
    {
        pSettings = GetComponent<PlayerMovement>();
    }


    // Update is called once per frame
    void Update()
    {
        textLoading.GetComponent<Text>().text = ((int)pSettings.reviveTime * 10).ToString() + "%";
        //textLoading.gameObject.SetActive(true);

        loadingBar.GetComponent<Image>().fillAmount = pSettings.reviveTime / 10;

    }
}
