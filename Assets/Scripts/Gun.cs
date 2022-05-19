using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Gun : MonoBehaviour
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
    public virtual void fireBullet()
    {
        PoolableObject tempBullet = bulletPool.GetObject();
        tempBullet.transform.position = bulletSpawn.position;
        tempBullet.transform.rotation = bulletSpawn.rotation;
        tempBullet.gameObject.GetComponent<Bullet>().shootBullet();
    }

    public virtual void createBulletPool()
    {
        if (bulletPool == null) {
            bulletPool = ObjectPooler.CreateInstance(playerBullet, 40);
        }
       
    }


    
}
