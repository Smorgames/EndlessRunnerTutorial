using TMPro;
using UnityEngine;

public class BestScoreUpdater : MonoBehaviour
{
    private TextMeshProUGUI _bestScoreTMP;
    
    private void Start()
    {
        _bestScoreTMP = GetComponent<TextMeshProUGUI>();
        _bestScoreTMP.text = $"Best score: {PlayerPrefs.GetInt("BestScore")}";
    }
}