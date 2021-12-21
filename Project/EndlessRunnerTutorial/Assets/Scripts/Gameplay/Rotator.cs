using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float MinRotationSpeed = -180f;
    public float MaxRotationSpeed = 180f;

    private float _rotationSpeed;

    private void Start()
    {
        _rotationSpeed = Random.Range(MinRotationSpeed, MaxRotationSpeed);
    }

    private void Update()
    {
        transform.Rotate(0f, 0f, _rotationSpeed * Time.deltaTime);
    }
}