using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int Score { get { return _score; } }
    private static int _score;

    private readonly string _bestScoreID = "BestScore";

    public void SaveBestScore()
    {
        var bestScore = PlayerPrefs.GetInt(_bestScoreID);
        
        if (_score > bestScore)
            PlayerPrefs.SetInt(_bestScoreID, _score);
    }
    
    public void IncreaseScore()
    {
        _score++;
    }
}