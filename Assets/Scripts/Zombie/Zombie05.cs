using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie05 : Enemies
{
    public override void Distance()
    {
        base.Distance();
    }
    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        damage = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        Distance();
    }
}
