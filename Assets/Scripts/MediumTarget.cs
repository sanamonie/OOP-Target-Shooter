using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumTarget : Target
{

   public override void Movement() 
   {
        base.Movement();
        speed += .25f * Time.deltaTime; 
   }
    public override void onHit()
    {
        if (!hit)
        {
            
            GameManager.Instance.addScore(2);
            startParticle(1, transform.position);
            gameObject.SetActive(false);
            hit = true;
        }
        
    }
}
