using UnityEngine;

public class RandomMeteorSpawner : MonoBehaviour
{
    private void Awake()
    {
        var randomMeteorPrefab = RandomMeteorFromPrefabStorage();
        var meteor = Instantiate(randomMeteorPrefab, transform.position, Quaternion.identity);
        meteor.transform.parent = transform;
    }

    private GameObject RandomMeteorFromPrefabStorage()
    {
        var prefabStorage = GameObject.FindGameObjectWithTag("PrefabStorage").GetComponent<PrefabStorage>();
        var meteorPrefabs = prefabStorage.MeteorPrefabs;
        var randomIndex = Random.Range(0, meteorPrefabs.Count);
        var randomMeteor = meteorPrefabs[randomIndex];
        return randomMeteor;
    }
}