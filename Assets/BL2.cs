using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

public class BL2 : MonoBehaviour,Ipopable
{
     public ObjectPool<GameObject> ObjectPool { get; set; }
    public int popCounter = 3; // Number of pops before release
    private int currentPopCount = 0;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
        UpdateText();
    }

    public void pop()
    {
        currentPopCount++;
        UpdateText();

        if (currentPopCount >= popCounter)
        {
            ObjectPool.Release(this.gameObject);
        }
    }

    private void UpdateText()
    {
        textMesh.text =  currentPopCount + " / " + popCounter;
    }

    public void setpool(ObjectPool<GameObject> pool)
    {
        ObjectPool = pool;
    }
}
