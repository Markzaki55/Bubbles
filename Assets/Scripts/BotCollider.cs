using System;

using TMPro;
using UnityEngine;


public class BotCollider : MonoBehaviour
{
    public int misscounter;
    [SerializeField] TextMeshProUGUI misscounterT;

    static event Action<int> OnPopMiss;
    public static event Action OnPopMissMax;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bubble") && !GameLoop.instance.Gameeded)
        {
            GameObject bubble = collision.gameObject;
            bubble.GetComponent<Ipopable>().ObjectPool.Release(collision.gameObject);
            misscounter++;
            if(misscounter >= 5) { OnPopMissMax?.Invoke();}
            misscounterT.text = "Miss :"+ misscounter;
        }
    }
}

