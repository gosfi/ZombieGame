using UnityEngine.Audio;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int nbOfBullets, maxBullets;
    public float range, dmg, aimSpeed, fireRate;
    public bool CanShoot;

    public Vector3 AimDownSight, HipFire; //0,-0.25,0.8

    public Camera fpsCam;

    public float nextTimeToFire;

    [HideInInspector]
    public AudioSource source;

    MuzzleFlash muzzleFlash;

    void Start()
    {
        muzzleFlash = GetComponent<MuzzleFlash>();
    }

    public void Shoot()
    {
        RaycastHit hit;
        nbOfBullets--;


        if (source.clip != null)
        {
            source.Play();
        }

        if (nbOfBullets <= 0)
        {
            CanShoot = false;
        }
        
        muzzleFlash.Activate();

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
        if (isAiming)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, AimDownSight, 15 * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, HipFire, 15 * Time.deltaTime);
        }
    }
}
