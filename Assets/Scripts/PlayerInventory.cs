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
        /* if (Input.GetKey(KeyCode.Alpha1))
         {
             slot1.SetActive(true);
             slot2.SetActive(false);
             slot3.SetActive(false);

             guns[0].SetActive(true);
             guns[1].SetActive(false);
             guns[2].SetActive(false);

         }
         if (Input.GetKey(KeyCode.Alpha2))
         {
             slot1.SetActive(false);
             slot2.SetActive(true);
             slot3.SetActive(false);

             guns[0].SetActive(false);
             guns[1].SetActive(true);
             guns[2].SetActive(false);
         }
         if (Input.GetKey(KeyCode.Alpha3))
         {
             /* slot1.SetActive(false);
              pistol.SetActive(false);

              slot2.SetActive(false);
              shotgun.SetActive(false);

              slot3.SetActive(true);
              ak_47.SetActive(true)

             guns[0].SetActive(false);
             guns[1].SetActive(false);
             guns[2].SetActive(true);
         }*/

        if (Input.GetAxis("Mouse ScrollWheel") >= 0.1f)
        {
            index++;

            if (index > guns.Length)
            {
                index = 0;
            }


            if (index == 0)
            {
                guns[index].SetActive(true);
                guns[index + 1].SetActive(false);
                guns[guns.Length].SetActive(false);
            }
            else if (index == guns.Length)
            {
                guns[index].SetActive(true);
                guns[index - 1].SetActive(false);
                guns[0].SetActive(false);
            }
            else
            {
                guns[index].SetActive(true);
                guns[index + 1].SetActive(false);
                guns[index - 1].SetActive(false);
            }


        }
    }

    private void Update()
    {
        Select();
        Debug.Log(guns.Length);
    }
}
