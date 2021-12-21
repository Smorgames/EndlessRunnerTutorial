using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTMP;
    [SerializeField] private TextMeshProUGUI _healthPointTMP;

    [SerializeField] private GameObject _pausePanel;

    private Rocket _rocket;
    private GameManager _gameManager;

    private void Start()
    {
        _rocket = GameObject.FindGameObjectWithTag("Rocket").GetComponent<Rocket>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        _scoreTMP.text = $"{GameManager.Score}";
        _healthPointTMP.text = $"{_rocket.CurrentHealthPoint}";
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        _pausePanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        _pausePanel.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        _gameManager.SaveBestScore();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}