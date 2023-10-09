using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] TextMeshProUGUI Highscore ;
    int score_count = 0;
    int _highscore = 0;

    public void InjectData( int Currentscore , int Highscore)
    {
        score_count = Currentscore;
        _highscore = Highscore;
        showData();
    }

    private void showData()
    {
        score.text = "Score : " + score_count;
        Highscore.text = "HighScore : " + _highscore;

    }

    public void Retry()
    {
        SceneManager.LoadScene("Game");
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Main menu");
    }



}
