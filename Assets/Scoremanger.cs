
using UnityEngine;
using TMPro;



public class Scoremanger : MonoBehaviour
{
    public TextMeshProUGUI Scoretext;
    public TimeRateHandler TimeRate;
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
        TimeRate.LerpTimeRate(score);
    }
}

[System.Serializable]
public class TimeRateHandler
{
    [SerializeField] float _baseTime = 1.0f;
    [SerializeField] float MaxTime = 10.0f;
    private float _currentTimeRate;

    public float CurrentTimeRate
    {
        get
        {
            return _currentTimeRate;
        }
    }
    public void LerpTimeRate(int score)
    {
        float stepValue = 1 + (2 * MaxTime * score) / (Mathf.Pow(MaxTime, 4) + score) ;      // This is to ensure a smooth increase from base time up untill 
        _currentTimeRate = stepValue;
        Time.timeScale = _currentTimeRate;
    }


}
