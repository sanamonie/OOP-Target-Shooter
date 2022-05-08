using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    public ObjectPooler Parent;
    // Start is called before the first frame update
    public virtual void OnDisable()
    {
        Parent.ReturnObjecToPool(this);
    }
}
