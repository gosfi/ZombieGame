using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    // Update is called once per frame

    private void OnEnable()
    {
        
        source = GetComponent<AudioSource>();
        CanShoot = true;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && CanShoot && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        Aim(Input.GetButton("Fire2"));

        UpdateSway();

    }

}
