using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] private Vector3 _moveOffset;
    [SerializeField] private float _moveSpeed = 100f;
    
    public int CurrentHealthPoint { get { return _currentHealthPoint; } }
    [SerializeField] private int _currentHealthPoint = 3;
    [SerializeField] private float _xClamp;
    
    private Vector2 _targetPosition;

    private GameManager _gameManager;

    private void Start()
    {
        _targetPosition = transform.position;
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        MoveBasedOnInput();
    }

    private void MoveBasedOnInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -_xClamp)
            _targetPosition = transform.position - _moveOffset;
        if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < _xClamp)
            _targetPosition = transform.position + _moveOffset;
    }

    public void TakeDamage()
    {
        _currentHealthPoint--;

        if (_currentHealthPoint <= 0)
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