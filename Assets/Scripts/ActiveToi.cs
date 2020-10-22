using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveToi : MonoBehaviour
{
    public GameObject wave;

    // Update is called once per frame
    void Update()
    {
        wave.SetActive(true);
    }
}
