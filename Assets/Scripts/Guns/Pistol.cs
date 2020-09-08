using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    // Update is called once per frame

    private void OnEnable()
    {
        CanShoot = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && CanShoot)
        {
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

}
