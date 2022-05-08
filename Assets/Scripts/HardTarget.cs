using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardTarget : Target
{
    public override void Movement()
    {
        base.Movement();
        speed += .5f * Time.deltaTime;
    }
}
