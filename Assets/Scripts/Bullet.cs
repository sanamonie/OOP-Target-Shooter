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

    void Update()
    {
        if (transform.position.x > 50 || transform.position.x < -50) {
            gameObject.SetActive(false);
        }
        if (transform.position.y > 50 || transform.position.y < -50)
        {
            gameObject.SetActive(false);
        }
        if (transform.position.z > 50 || transform.position.z < -50)
        {
            gameObject.SetActive(false);
        }
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
            switch (other.gameObject.name)
            {
                case "Start Target":
                    GameManager.Instance.StartGame();
                    other.gameObject.SetActive(false);
                    break;
                case "Menu":
                    GameManager.Instance.loadmenu();
                    other.gameObject.SetActive(false);
                    break;
                default:
                    var targetScript = other.gameObject.GetComponent<Target>();
                    targetScript.onHit();
                    break;
            }

            
        }
        gameObject.SetActive(false);
        //if state to check if collider contains target abstract class 
    }
}
