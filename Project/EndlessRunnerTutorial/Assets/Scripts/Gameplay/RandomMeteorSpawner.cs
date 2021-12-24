using System.Collections.Generic;
using UnityEngine;

public class RandomMeteorSpawner : MonoBehaviour
{
    public List<GameObject> Meteors;
    
    private void Awake()
    {
        var randomMeteorPrefab = RandomMeteorFromPrefabStorage();
        var meteor = Instantiate(randomMeteorPrefab, transform.position, Quaternion.identity);
        meteor.transform.parent = transform;
    }

    private GameObject RandomMeteorFromPrefabStorage()
    {
        var randomIndex = Random.Range(0, Meteors.Count);
        var randomMeteor = Meteors[randomIndex];
        return randomMeteor;
    }
}