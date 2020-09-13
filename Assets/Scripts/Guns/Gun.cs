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

    private Quaternion targetRotation, originRotation;

    public float intensity, smooth;

    string rayCastName;

    public EnemySettings zombie;


    private void Start()
    {
        muzzleFlash = GetComponent<MuzzleFlash>();
        originRotation = transform.localRotation;
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
            if(hit.transform.CompareTag("Zombie")){
                zombie.Hit(dmg);
            }
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

    public void UpdateSway()
    {
        float t_x_mouse = Input.GetAxis("Mouse X");
        float t_y_mouse = Input.GetAxis("Mouse Y");

        //calculate adjustment
        Quaternion t_x_adj = Quaternion.AngleAxis(-intensity * t_x_mouse, Vector3.up);
        Quaternion t_y_adj = Quaternion.AngleAxis(intensity * t_y_mouse, Vector3.right);
        targetRotation = t_x_adj * t_y_adj * originRotation;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * smooth);
    }
}
