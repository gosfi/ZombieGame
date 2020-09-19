using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    bool active = false;
    bool shotgunActive = false;
    bool ak47Active = false;

    public int playerMoney;
    public int buyMoney;
    public Text playerMoneyText;
    public Text buyText;
    public GameObject panel;
    public GameObject line1;
    public GameObject line2;
    public PlayerInventory player;
    public GameObject shotgun;
    public GameObject ak47;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!active)
            {
                active = true;
            }
            else
            {
                active = false;
            }

            panel.SetActive(active);
        }

        playerMoneyText.text = playerMoney.ToString();
    }

    public void SelectShotgun()
    {
        shotgunActive = true;
        ak47Active = false;

        line1.SetActive(shotgunActive);
        line2.SetActive(ak47Active);
        buyText.text = "500";
    }
    public void SelectAk47()
    {
        shotgunActive = false;
        ak47Active = true;

        line1.SetActive(shotgunActive);
        line2.SetActive(ak47Active);
        buyText.text = "1 000";

    }

    public void Buy() { 
        
        if(shotgunActive && playerMoney >= 500)
        {
            for(int i = 0; i < player.guns.Length; i++)
            {
                player.guns[i].SetActive(false);
                player.slots[i].SetActive(false);
            }
            player.guns[1].SetActive(true);
            player.slots[1].SetActive(true);

            playerMoney -= 500;
        }

        if(ak47Active && playerMoney >= 1000)
        {
            for (int i = 0; i < player.guns.Length; i++)
            {
                player.guns[i].SetActive(false);
                player.slots[i].SetActive(false);
            }
            player.guns[2].SetActive(true);
            player.slots[2].SetActive(true);

            playerMoney -= 1000;

        }

    }
}
