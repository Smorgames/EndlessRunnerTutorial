using UnityEngine;

public class Meteor : MonoBehaviour
{
    [SerializeField] private GameObject _explosionPrefab;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        var rocket = other.GetComponent<Rocket>();

        if (rocket != null)
        {
            rocket.TakeDamage();
            Death();
        }
    }

    private void Death()
    {
        Explode();
        Camera.main.GetComponent<MainCamera>().ShakeCamera();
        FindObjectOfType<AudioManager>().Boom();
        Destroy(gameObject);
    }

    private void Explode()
    {
        Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
    }
}