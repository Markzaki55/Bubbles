using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

interface Ipopable{
  ObjectPool<GameObject> ObjectPool { get; set; }
  void setpool(ObjectPool<GameObject> pool);
    void pop();
    
}
   
public class LB1 : MonoBehaviour,Ipopable
{
   public ObjectPool<GameObject> ObjectPool { get; set; }
    PoppableObjectSpawner pool;
   


    public void pop()
    {
       ObjectPool.Release(this.gameObject);
        
    }

    public void setpool(ObjectPool<GameObject> pool)
    {
        ObjectPool = pool;
    }
}
