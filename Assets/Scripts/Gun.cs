using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField]
    PoolableObject playerBullet;
    ObjectPooler bulletPool;
 

    [SerializeField]
    Transform bulletSpawn;
  

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
        bulletPool = ObjectPooler.CreateInstance(playerBullet, 40);
    }


    
}
