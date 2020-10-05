using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInventory : NetworkBehaviour
{
  

    public GameObject[] guns = new GameObject[3];
    public GameObject[] slots = new GameObject[3];
    public GameObject[] ammo = new GameObject[3];

    int index = 0;


    void Select()
    {
        if (Input.GetAxis("Mouse ScrollWheel") >= 0.1f)
        {
            if (index <= 2)
            {
                index++;
            }
            if(index >= 3)
            {
                index = 0;
            }

            for (int i = 0; i < guns.Length; ++i)
            {
                guns[i].SetActive(false);
                slots[i].SetActive(false);
                ammo[i].SetActive(false);
            }

            guns[index].SetActive(true);
            slots[index].SetActive(true);
            ammo[index].SetActive(true);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") <= -0.1f)
        {
            if (index >= 0)
            {
                index--;
            }
            if (index < 0)
            {
                index = 2;
            }

            for (int i = 0; i < guns.Length; ++i)
            {
                guns[i].SetActive(false);
                slots[i].SetActive(false);
                ammo[i].SetActive(false);
            }

            guns[index].SetActive(true);
            slots[index].SetActive(true);
            ammo[index].SetActive(true);
        }
    }

    private void Update()
    {
        Select();
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
    }
}
