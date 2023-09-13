using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;

public class BotCollider : MonoBehaviour
{
    int misscounter;
    [SerializeField] TextMeshProUGUI misscounterT;

    static event Action<int> OnPopMiss;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bubble"))
        {
            collision.gameObject.GetComponent<Ipopable>().ObjectPool.Release(collision.gameObject);
            misscounter++;
            misscounterT.text = "Miss :"+ misscounter;
        }
    }
}

