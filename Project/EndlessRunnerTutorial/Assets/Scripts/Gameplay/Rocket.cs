using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Vector3 MoveOffset = new Vector3(2f, 0f, 0f);
    public float MoveSpeed = 100f;
    public int CurrentHealthPoint = 3;
    public float XClamp = 2f;
    
    private Vector2 _targetPosition;
    private GameManager _gameManager;

    private void Start()
    {
        _targetPosition = transform.position;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, MoveSpeed * Time.deltaTime);
        MoveBasedOnInput();
    }

    private void MoveBasedOnInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -XClamp)
            _targetPosition = transform.position - MoveOffset;
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < XClamp)
            _targetPosition = transform.position + MoveOffset;
    }

    public void TakeDamage()
    {
        CurrentHealthPoint--;

        if (CurrentHealthPoint <= 0)
            Death();
    }

    private void Death()
    {
        _gameManager.SaveBestScore();
        FindObjectOfType<AudioManager>().Lose();
        _gameManager.LoseGame();
        Destroy(gameObject);
    }
}