using System;

using TMPro;
using UnityEngine;


public class BotCollider : MonoBehaviour
{
    int misscounter;
    [SerializeField] TextMeshProUGUI misscounterT;

    static event Action<int> OnPopMiss;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bubble"))
        {
            GameObject bubble = collision.gameObject;
            bubble.GetComponent<Ipopable>().ObjectPool.Release(collision.gameObject);
            misscounter++;
            misscounterT.text = "Miss :"+ misscounter;
        }
    }
}

