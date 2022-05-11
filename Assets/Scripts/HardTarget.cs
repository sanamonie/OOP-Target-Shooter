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
    public override void onHit()
    {
        GameManager.Instance.addScore(3);
        startParticle(2, transform.position);
    }
}
