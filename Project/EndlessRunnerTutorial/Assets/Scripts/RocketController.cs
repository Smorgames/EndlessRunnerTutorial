using UnityEngine;

public class RocketController : MonoBehaviour
{
    [SerializeField] private Vector3 _moveOffset;
    [SerializeField] private float _moveSpeed = 100f;
    
    [SerializeField] private int _currentHP = 3;
    
    private Vector2 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            _targetPosition = transform.position - _moveOffset;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            _targetPosition = transform.position + _moveOffset;
    }

    public void TakeDamage()
    {
        
    }
}