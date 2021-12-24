using UnityEngine;

public class TestRocket : MonoBehaviour
{
    public Vector3 MoveOffset;
    public float Speed;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            _targetPosition = transform.position - MoveOffset;
        if (Input.GetKeyDown(KeyCode.RightArrow))
            _targetPosition = transform.position + MoveOffset;
    }
}