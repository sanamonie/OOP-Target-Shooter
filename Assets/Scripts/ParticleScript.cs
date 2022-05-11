using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : PoolableObject
{
    ParticleSystem pSystem;
    private void Awake()
    {
       pSystem = gameObject.GetComponent<ParticleSystem>();
    }

    public void playParticle() {
        pSystem.Play();
        Invoke("destroyParticle", 1);
    }

    private void destroyParticle() {
        if (!pSystem.isStopped) {
            pSystem.Stop();
        }
        
        gameObject.SetActive(false);
    }
}
