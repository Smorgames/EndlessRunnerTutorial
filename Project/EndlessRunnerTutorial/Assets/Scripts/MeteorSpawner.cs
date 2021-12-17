using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _meteorSetPrefabs;
    
    public static float SpawnInterval = 1.23f;
    private float _counter;
    
    private void Update()
    {
        _counter += Time.deltaTime;

        if (_counter >= SpawnInterval)
        {
            SpawnMeteorSet();
            _counter = 0f;
        }
    }

    private void SpawnMeteorSet()
    {
        var randomIndex = Random.Range(0, _meteorSetPrefabs.Count);
        var meteorSet = _meteorSetPrefabs[randomIndex];
        Instantiate(meteorSet, transform.position, Quaternion.identity);
    }

    public static void SetSpawnInterval(float spawnInterval) => SpawnInterval = spawnInterval;
}