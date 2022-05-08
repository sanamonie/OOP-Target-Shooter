using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : PoolableObject
{

    public Vector3 dirrection;
   protected float speed = 5;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }


    public virtual void Movement()
    {
        transform.Translate(dirrection*Time.deltaTime*speed);
    }


    //movement
    //collsion effect
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "RBounds") {
            gameObject.SetActive(false);
            GameManager.Instance.changeLife(-1);
        }
    }

}
