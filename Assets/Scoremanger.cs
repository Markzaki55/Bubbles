using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Scoremanger : MonoBehaviour
{
    public TextMeshProUGUI Scoretext;
    private int score = 0;

    private void OnEnable()
    {
        bubble.Onpopscorechange += IncreaseScore;

    }
    private void OnDisable()
    {
        bubble.Onpopscorechange -= IncreaseScore;
    }

    public int GetScore()
    {
        return score;
    }

    public void IncreaseScore(bubble bubble) {
        score += bubble.Scoreadded;

        Scoretext.text = $"Score : {score}";
    }
    

}
