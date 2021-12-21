using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _minRotationSpeed;
    [SerializeField] private float _maxRotationSpeed;

    private float _rotationSpeed;

    private void Start()
    {
        _rotationSpeed = Random.Range(_minRotationSpeed, _maxRotationSpeed);
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
    }
}