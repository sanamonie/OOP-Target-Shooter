using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunTarget : Target
{
    // INHERITANCE
    public override void Movement()
    {
        base.Movement();

    }
    // POLYMORPHISM
    public override void onHit()
    {
        if (!hit)
        {
            GameManager.Instance.addScore(1);
            startParticle(0, transform.position);
            playerScript.equipGun(1);
            hit = true;
            gameObject.SetActive(false);
        }

    }
}
