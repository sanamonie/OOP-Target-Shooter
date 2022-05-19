using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Target : PoolableObject
{

    public Vector3 dirrection;
    protected float speed = 5;


    public delegate void pDelegate(int pIndex, Vector3 partPosition);
    public pDelegate startParticle;
    protected Player playerScript;

    protected Coroutine onHitRoutine;

    public bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
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

    public abstract void onHit();
    

    private void OnEnable()
    {
        hit = false;
    }

    //movement
    //collsion effect
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "RBounds")
        {
            gameObject.SetActive(false);
            GameManager.Instance.changeLife(-1);
        }
    }

    

}
