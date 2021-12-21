using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreTMP;
    public TextMeshProUGUI HealthPointTMP;
    public GameObject PausePanel;
    public GameObject DeathPanel;

    private Rocket _rocket;
    private GameManager _gameManager;

    private void Start()
    {
        _rocket = GameObject.FindGameObjectWithTag("Rocket").GetComponent<Rocket>();
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        ScoreTMP.text = $"{_gameManager.Score}";
        HealthPointTMP.text = $"{_rocket.CurrentHealthPoint}";
    }

    public void Lose()
    {
        Time.timeScale = 0f;
        DeathPanel.SetActive(true);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        PausePanel.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        _gameManager.SaveBestScore();
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}