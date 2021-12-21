using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    private static float _speed = 10f;
    private static Vector3 _direction = Vector3.down;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(_speed * Time.deltaTime * _direction, Space.World);
    }
}