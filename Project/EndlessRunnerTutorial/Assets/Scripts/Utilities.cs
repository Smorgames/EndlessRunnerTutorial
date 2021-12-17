using TMPro;
using UnityEngine;

public class Utilities : MonoBehaviour
{
    private float _meteorSpeed;
    private float _spawnInterval;

    [SerializeField] private TextMeshProUGUI _meteorsSpeedTMP;
    [SerializeField] private TextMeshProUGUI _spawnIntervalTMP;

    private void Start()
    {
        _meteorSpeed = MeteorMovement.Speed;
        _spawnInterval = MeteorSpawner.SpawnInterval;
        
        _spawnIntervalTMP.text = $"Spawn interval: '{_spawnInterval}'";
        _meteorsSpeedTMP.text = $"Meteors speed: '{_meteorSpeed}'";
    }

    public void IncreaseMeteorsSpeed()
    {
        _meteorSpeed += 0.7f;
        MeteorMovement.SetSpeed(_meteorSpeed);
        _spawnInterval -= 0.1f;
        MeteorSpawner.SetSpawnInterval(_spawnInterval);

        _spawnIntervalTMP.text = $"Spawn interval: '{_spawnInterval}'";
        _meteorsSpeedTMP.text = $"Meteors speed: '{_meteorSpeed}'";
    }
}