using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public List<PoolableObject> particles = new List<PoolableObject>();
    List<ObjectPooler> particlePools = new List<ObjectPooler>();


    

    // Start is called before the first frame update
    void Start()
    {
        foreach (PoolableObject particle in particles) {
            var tempPool = ObjectPooler.CreateInstance(particle, 30);
            particlePools.Add(tempPool);
            
        }
    }
    // ABSTRACTION
    // method/expression to be added to delegate held in abstract Target class
    public void spawnParticle(int particleIndex, Vector3 spawnPosition) {

        var particleEffect = particlePools[particleIndex].GetObject();
        particleEffect.transform.position = spawnPosition;
        ParticleScript tempScript = particleEffect.GetComponent<ParticleScript>();
        tempScript.playParticle();
    }
}
