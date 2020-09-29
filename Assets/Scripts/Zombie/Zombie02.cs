using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie02 : Enemies
{
    public override void Distance()
    {
        base.Distance();        
    }

    // Start is called before the first frame update
    void Start()
    {
        damage = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        Distance();
    }
}
