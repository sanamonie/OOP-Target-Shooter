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
}