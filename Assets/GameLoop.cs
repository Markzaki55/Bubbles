using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public GameObject LosePanel;
    public bool Gameeded;
 //   public static GameLoop instance;

    private void Awake()
    {
     
        //if (instance == null)
        //{
        //    instance = this;
        //    DontDestroyOnLoad(gameObject);
        //    DontDestroyOnLoad(LosePanel);
        //}
        //else
        //{
        //  //  Destroy(gameObject);
        //}
        Gameeded = false;
    }
    private void OnEnable()
    {
        DontDestroyOnLoad(LosePanel);
        BotCollider.OnPopMissMax += HandleLose;
    }

    private void HandleLose()
    {
        Gameeded= true;
        int CurrentScore = FindAnyObjectByType<Scoremanger>().score;
        SaveManger.highScore += CurrentScore;
        int highestscore = SaveManger.highScore;
        SaveManger.Save();
        LosePanel.SetActive(true);
        LosePanel.transform.parent.GetComponent<GameOverPanelHandler>().InjectData(CurrentScore, highestscore);
        GameObject spawner = FindAnyObjectByType<PoppableObjectSpawner>().gameObject;
        spawner.SetActive(false);
        bubble[] Bubbles = FindObjectsOfType<bubble>();
        foreach (bubble b in Bubbles)
        {
            if (b != null && b.gameObject != null)
            {
                Destroy(b.gameObject);
            }
        }
        Gameeded = false;

    }

    private void OnDisable()
    {
        BotCollider.OnPopMissMax -= HandleLose;
    }
    //private void Reset()
    //{
    //    LosePanel.SetActive(false);
    //}

}
