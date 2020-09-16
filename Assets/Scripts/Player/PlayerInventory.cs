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
        if (Input.GetAxis("Mouse ScrollWheel") >= 0.1f)
        {
            if (index <= guns.Length - 1)
            {
                index++;
            }
            else
            {
                index = 0;
            }

            for (int i = 0; i < guns.Length; ++i)
            {
                guns[i].SetActive(false);
            }

            guns[index].SetActive(true);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") <= -0.1f)
        {
            if (index >= 0)
            {
                index--;
            }
            else
            {
                index = 2;
            }

            for (int i = 0; i < guns.Length; ++i)
            {
                guns[i].SetActive(false);
            }

            guns[index].SetActive(true);
        }
    }

    private void Update()
    {
        Select();
        Debug.Log(Input.GetAxis("Mouse ScrollWheel"));
    }
}
