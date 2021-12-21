using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameUIManager GameUIManager;
    
    public int Score { get { return _score; } }
    private int _score;

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

    public void LoseGame()
    {
        GameUIManager.Lose();
    }
}