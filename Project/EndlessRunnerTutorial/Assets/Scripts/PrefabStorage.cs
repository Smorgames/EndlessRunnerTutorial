using System.Collections.Generic;
using UnityEngine;

public class PrefabStorage : MonoBehaviour
{
    public List<GameObject> MeteorPrefabs => _meteorPrefabs;
    [SerializeField] private List<GameObject> _meteorPrefabs;
}