using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class LookAtCamera : NetworkBehaviour
{
    public new Camera camera;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + camera.transform.rotation * Vector3.forward, camera.transform.rotation * Vector3.up);
    }
}
