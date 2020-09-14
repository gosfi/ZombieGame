using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public GameObject[] guns = new GameObject[3];

    int index = 0;


    void Select()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            index = 0;
            slot1.SetActive(true);
            slot2.SetActive(false);
            slot3.SetActive(false);

            for (int i = 0; i < guns.Length; i++)
            {
                guns[i].SetActive(false);
            }
            guns[index].SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            index = 1;
            slot1.SetActive(false);
            slot2.SetActive(true);
            slot3.SetActive(false);

            for (int i = 0; i < guns.Length; i++)
            {
                guns[i].SetActive(false);
            }
            guns[index].SetActive(true);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            index = 2;
            slot1.SetActive(false);
            slot2.SetActive(false);
            slot3.SetActive(true);

            for (int i = 0; i < guns.Length; i++)
            {
                guns[i].SetActive(false);
            }
            guns[index].SetActive(true);
        }
    }

    private void Update()
    {
        Select();
        Debug.Log(index);
    }
}
