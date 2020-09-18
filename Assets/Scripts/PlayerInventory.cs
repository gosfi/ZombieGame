using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public GameObject[] slots = new GameObject[3];

    public GameObject[] guns = new GameObject[3];

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
            }

            guns[index].SetActive(true);
            slots[index].SetActive(true);

        }
        else if (Input.GetAxis("Mouse ScrollWheel") <= -0.1f)
        {
            if (index >= 0)
            {
                index--;
            }
            if (index <= -1)
            {
                index = 2;
            }

            for (int i = 0; i < guns.Length; ++i)
            {
                guns[i].SetActive(false);
                slots[i].SetActive(false);

            }

            guns[index].SetActive(true);
            slots[index].SetActive(true);

        }
    }

    private void Update()
    {
        Select();
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
    }
}
