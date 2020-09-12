using UnityEngine.Audio;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Variables
    public int nbOfBullets, maxBullets;
    public float range, dmg, aimSpeed, fireRate;
    public bool CanShoot;

    public Vector3 AimDownSight, HipFire; //0,-0.25,0.8

    public Camera fpsCam;

    public float nextTimeToFire;

    [HideInInspector]
    public AudioSource source;

    MuzzleFlash muzzleFlash;
    #endregion

    private Quaternion targetRotation, originRotation;

    public float intensity, smooth;


    private void Start()
    {
        muzzleFlash = GetComponent<MuzzleFlash>();
        originRotation = transform.localRotation;
    }

    public void Shoot()
    {
        //create a new RaycastHit object and reduces the numbers of bullet when shooting
        RaycastHit hit;
        nbOfBullets--;

        //Check if the audio source clip is not null, if it isn't null play the clip
        if (source.clip != null)
        {
            source.Play();
        }

        //if the number of bullets is less or equal to 0, the player can't shoot

        if (nbOfBullets <= 0)
        {
            CanShoot = false;
        }

        //set active the muzzle flash object, check MuzzleFlash.cs for more infos
        muzzleFlash.Activate();

        //shoot a raycast from the middle of the camera, check if it hit something
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //TODO: replace logging the name of what you hit to giving it damage and adding force to give an impression of power to the player
            Debug.Log(hit.transform.name);
        }

    }

    public void Reload()
    {
        //put all the ammo back to the gun and make the player able to shoot again
        nbOfBullets = maxBullets;
        CanShoot = true;
    }

    public void Aim(bool isAiming)
    {
        // if the player is clicking the aim button, lerp between current position and the Vector 3 assigned in the editor for the aiming position
        if (isAiming)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, AimDownSight, 15 * Time.deltaTime);
        }
        //if the player isn't clicking the aiming button, lerp between aiming position and the hip position assigned in the editor
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
