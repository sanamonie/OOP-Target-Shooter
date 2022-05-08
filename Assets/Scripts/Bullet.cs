using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : PoolableObject
{
    
    public Rigidbody RB;
    public Vector3 shootDirrection= Vector3.forward;
   // public Transform bullet
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnEnable()
    {
      //  Invoke("AutoDisable", 5f);

       
        

    }
    public override void OnDisable()
    {
        base.OnDisable();
        RB.velocity = Vector3.zero;
    }


    public virtual void shootBullet() {
        RB.AddForce(transform.up*100, ForceMode.Impulse);
    }
    void AutoDisable() {
        gameObject.SetActive(false);
    }

     void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Target") {
            Debug.Log(other.gameObject.name);
            switch (other.gameObject.name)
            {
                case"Target(Clone)": 
                    GameManager.Instance.addScore(1);
                    break;
                case "Target 2(Clone)":
                    GameManager.Instance.addScore(2);
                    break;
                case "Target 3(Clone)":
                    GameManager.Instance.addScore(3);
                    break;
                case "Start Target":
                    GameManager.Instance.StartGame();
                    break;
            }

            other.gameObject.SetActive(false);
        }
        gameObject.SetActive(false);
        //if state to check if collider contains target abstract class 
    }
}
