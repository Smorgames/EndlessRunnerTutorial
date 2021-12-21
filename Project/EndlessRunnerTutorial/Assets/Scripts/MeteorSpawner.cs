using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _meteorSetPrefabs;
    
    private float _spawnInterval = 1f;
    private float _counter;
    private readonly float _deltaDecreaseTime = 0.05f;
    private readonly float _minSpawnTime = 0.455f;

    private void Update()
    {
        _counter += Time.deltaTime;

        if (_counter >= _spawnInterval)
        {
            if (_spawnInterval > _minSpawnTime)
                _spawnInterval -= _deltaDecreaseTime;
            
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
}