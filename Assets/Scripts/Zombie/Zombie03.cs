﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie03 : Enemies
{

    public override void Distance()
    {
        base.Distance();
    }
    // Start is called before the first frame update
    void Start()
    {
        damage = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        Distance();
    }
}
