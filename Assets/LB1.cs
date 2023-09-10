using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


interface Ipopable{
  ObjectPool<GameObject> ObjectPool { get; set; }
  void setpool(ObjectPool<GameObject> pool);
    void pop();
    
}
   
public class LB1 : bubble, Ipopable 
{
   public ObjectPool<GameObject> ObjectPool { get; set; }
    PoppableObjectSpawner pool;
   


    public void pop()
    {

        StartCoroutine(popping(this.gameObject));
       }
    private IEnumerator popping(GameObject obj)
    {
        Vector3 originalScale = obj.transform.localScale;
        Vector3 targetScale = Vector3.zero;
        float elapsedTime = 0f;

        while (elapsedTime < 1)
        {
            float t = elapsedTime / 1;
            obj.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.localScale = targetScale;
        obj.SetActive(false);
        obj.transform.localScale = originalScale; 
        base.pop(ObjectPool);


    }

    public void setpool(ObjectPool<GameObject> pool)
    {
        ObjectPool = pool;
    }
}



public class bubble: MonoBehaviour{ 


 public  virtual void pop(UnityEngine.Pool.ObjectPool<GameObject> pool)
    {
        pool.Release(this.gameObject);
    }

}