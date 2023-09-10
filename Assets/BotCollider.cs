using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BotCollider : MonoBehaviour
{
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bubble"))
        {
            collision.gameObject.GetComponent<Ipopable>().ObjectPool.Release(collision.gameObject);
        }
    }



}

