using System;
using System.Collections;

using UnityEngine;
using UnityEngine.Pool;
interface Ipopable{
  ObjectPool<GameObject> ObjectPool { get; set; }
  void setpool(ObjectPool<GameObject> pool);
    void pop();
    
}
public abstract class bubble : MonoBehaviour
{


    public static event Action<bubble> Onpopscorechange;
    [SerializeField] int _scoreadded;

    public int Scoreadded { get => _scoreadded; }

    public virtual void pop(UnityEngine.Pool.ObjectPool<GameObject> pool)
    {
        pool.Release(this.gameObject);
        Onpopscorechange?.Invoke(this);
    }

}

public class LB1 : bubble, Ipopable 
{
    [SerializeField] float popanim = 0.5f;   
        public ObjectPool<GameObject> ObjectPool { get; set; }
    

    public void pop()
    {

        StartCoroutine(popping(this.gameObject));
       }
    private IEnumerator popping(GameObject obj)
    {
        Vector3 originalScale = obj.transform.localScale;
        Vector3 targetScale = Vector3.zero;
        float elapsedTime = 0f;

        while (elapsedTime < popanim)
        {
            float t = elapsedTime / popanim;
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

