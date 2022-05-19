using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Gun : MonoBehaviour
{

    [SerializeField]
    protected PoolableObject playerBullet;
    protected ObjectPooler bulletPool;
 

    [SerializeField]
    protected Transform bulletSpawn;

    public delegate void ShotAction();
    public ShotAction shotFired;

    


    private void OnEnable()
    {
        createBulletPool();
    }
    public abstract void fireBullet();

    public abstract void createBulletPool();


    
}
