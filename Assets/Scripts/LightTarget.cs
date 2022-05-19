using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTarget : Target
{
    // INHERITANCE
    // Start is called before the first frame update
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
            hit = true;
            gameObject.SetActive(false);
        }
        
    }
}
