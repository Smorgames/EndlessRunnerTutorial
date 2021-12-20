using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    private static float _speed = 2.5f;
    private static Vector3 _direction = Vector3.down;
    
    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _direction, Space.World);
    }

    public static void SetSpeed(float speed)
    {
        _speed = speed;
    }
}