using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotGun : Gun
{
    public Text ammoShotgun;
    // Update is called once per frame

    private void OnEnable()
    {
        // get the audioCLip at the start of the game, and make the player able to shoot
        source = GetComponent<AudioSource>();
        CanShoot = true;
    }

    void Update()
    {
        // check what button the player is pressing
        if (Input.GetButtonDown("Fire1") && CanShoot && Time.time >= nextTimeToFire)
        {
            //if the player press the shoot button and he has enough ammo and current time is higher than nextTimeToFire
            //reset nextTimeToFire and use the shoot method in the Gun.cs script
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            //use the reload in the Gun.cs script
            Reload();
        }

        //check if the player has clicked on the aiming button, play the aim method in Gun.cs
        Aim(Input.GetButton("Fire2"));

        UpdateSway();

        ammoShotgun.text = nbOfBullets.ToString();
    }
}
