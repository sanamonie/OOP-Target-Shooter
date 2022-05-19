using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{

    //shotgun
    private int amounttospawn= 3;
    private int ringsToSpawn =2;
    private float distanceIncrease= .05f;
    private float[] distanceRange;
    private float[] angleRange;
    private int forSpacer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void fireBullet()
    {
        //base.fireBullet();
        List<PoolableObject> bullets = new List<PoolableObject>();

         distanceRange = new float[2] { .1f, .8f };
         angleRange = new float[2] { 0.0f, 3f };

        for (int j = 0; j < ringsToSpawn; j++)
        {
            forSpacer = 360 / amounttospawn;
            //this for loop spawns the circle using 4 quadrants using sin cos
            float ringOffset = Random.Range(0, 180);

            for (float i = ringOffset; i < 360 + ringOffset; i += forSpacer)
            {
                float randomAngle = Random.Range(angleRange[0], angleRange[1]);
                float randomDistance = Random.Range(distanceRange[0], distanceRange[1]);
                //gets the x,y coordinates for circle,  offset is position of instantiating object
                float iRadian = i * Mathf.Deg2Rad;
                float yPoint = Mathf.Sin(iRadian) * randomDistance;
                float xPoint = Mathf.Cos(iRadian) * randomDistance;

                float yRotation = Mathf.Sin(iRadian) * randomAngle;
                float xRotation = Mathf.Cos(iRadian) * randomAngle;
                Vector3 offSetEuler = new Vector3(yRotation, 0, xRotation);



                Vector3 offSet = new Vector3(xPoint, yPoint, 0);

                //applies 90 degree rotation
                Quaternion bulletRotation = bulletSpawn.transform.rotation;
                //applies offset from center
                bulletRotation *= Quaternion.Euler(offSetEuler);
                Quaternion emptyQuat = Quaternion.Euler(0, 0, 0);
                var curentBullet = bulletPool.GetObject();
                curentBullet.transform.position = bulletSpawn.position;
                curentBullet.transform.rotation = bulletRotation;
                // curentBullet.transform.localPosition = offSet;

                bullets.Add(curentBullet);

            }

            //amounttospawn += 1;
          //  distanceRange[0] += distanceIncrease;
          //  distanceRange[1] += distanceIncrease;
            angleRange[0] += 1f;
            angleRange[1] += 1.3f;
        }

        foreach (PoolableObject bulletV in bullets) {
            bulletV.GetComponent<Bullet>().shootBullet();
        }

        shotFired();
    }

    public override void createBulletPool()
    {
        if (bulletPool == null)
        {
            bulletPool = ObjectPooler.CreateInstance(playerBullet, 100);
        }
    }
}
