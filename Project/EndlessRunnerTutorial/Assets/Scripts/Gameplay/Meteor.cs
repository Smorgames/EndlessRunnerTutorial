using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    
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
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MainCamera>().ShakeCamera();
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().Boom();
        Destroy(gameObject);
    }

    private void Explode()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
    }
}