using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardTarget : Target
{
    // INHERITANCE
    public override void Movement()
    {
        base.Movement();
        speed += .5f * Time.deltaTime;
    }
    // POLYMORPHISM
    public override void onHit()
    {
        if (!hit) {
            GameManager.Instance.addScore(3);
            startParticle(2, transform.position);
            gameObject.SetActive(false);
            hit = true;
        }
        
    }
}
