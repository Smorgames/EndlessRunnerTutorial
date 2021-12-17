using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private TextMeshProUGUI _healthPointTMP;
    [SerializeField] private Button _pauseBTN;

    private void Update()
    {
        _scoreTMP.text = $"{ScoreHandler.Score}";
    }
}