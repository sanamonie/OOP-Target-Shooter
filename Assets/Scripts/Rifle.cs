using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Gun
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void fireBullet()
    {
        PoolableObject tempBullet = bulletPool.GetObject();
        tempBullet.transform.position = bulletSpawn.position;
        tempBullet.transform.rotation = bulletSpawn.rotation;
        tempBullet.gameObject.GetComponent<Bullet>().shootBullet();
    }
    public override void createBulletPool()
    {
        if (bulletPool == null)
        {
            bulletPool = ObjectPooler.CreateInstance(playerBullet, 40);
        }
    }
}
