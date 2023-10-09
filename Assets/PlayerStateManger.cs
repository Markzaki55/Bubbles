using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStateManger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI HighscoreText;
    private int highScore;
    void Start()
    {
        SaveManger.Load();
        highScore = SaveManger.highScore;
        HighscoreText.text = "HIGHSCORE: " + highScore;
    }
}
