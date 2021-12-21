using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        var rocket = other.GetComponent<Rocket>();

        if (rocket != null)
        {
            _gameManager.IncreaseScore();
            Destroy(gameObject);
        }
    }
}