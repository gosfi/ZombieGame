using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject slot1;
    public GameObject slot2;
    public GameObject slot3;

    public GameObject pistol;
    public GameObject shotgun;
    public GameObject ak_47;


    void Select()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            slot1.SetActive(true);
            pistol.SetActive(true);

            slot2.SetActive(false);
            shotgun.SetActive(false);

            slot3.SetActive(false);
            ak_47.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            slot1.SetActive(false);
            pistol.SetActive(false);

            slot2.SetActive(true);
            shotgun.SetActive(true);

            slot3.SetActive(false);
            ak_47.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            slot1.SetActive(false);
            pistol.SetActive(false);

            slot2.SetActive(false);
            shotgun.SetActive(false);

            slot3.SetActive(true);
            ak_47.SetActive(true);
        }
    }

    private void Update()
    {
        Select();
    }
}
