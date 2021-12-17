using UnityEngine;

public class MeteorMovement : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    
    public static float Speed => _speed;
    private static float _speed = 2.5f;

    private static Vector3 _direction = Vector3.down;

    private void Update() => transform.Translate(_speed * Time.deltaTime * _direction, Space.World);

    private void OnTriggerEnter2D(Collider2D other)
    {
        var rocket = other.GetComponent<RocketController>();

        if (rocket != null)
        {
            rocket.TakeDamage();
            Death();
        }
    }

    private void Death()
    {
        Explode();
        Destroy(gameObject);
    }

    private void Explode()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
    }


    public static void SetSpeed(float speed) => _speed = speed;
}