using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int nbOfBullets, maxBullets;
    public float range, dmg, aimSpeed, fireRate;
    public bool CanShoot;

    public Camera fpsCam;

    public float nextTimeToFire;

    public void Shoot()
    {
        RaycastHit hit;
        nbOfBullets--;

        if (nbOfBullets <= 0)
        {
            CanShoot = false;
        }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
        }
    }

    public void Reload()
    {
        nbOfBullets = maxBullets;
        CanShoot = true;
    }

    public virtual void Aim(bool isAiming)
    {

    }
}
