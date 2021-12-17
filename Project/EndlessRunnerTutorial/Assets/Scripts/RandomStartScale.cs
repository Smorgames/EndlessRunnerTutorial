using UnityEngine;

public class RandomStartScale : MonoBehaviour
{
    [SerializeField] private float _minScale;
    [SerializeField] private float _maxScale;

    private void Awake()
    {
        var scale = Random.Range(_minScale, _maxScale);
        transform.localScale *= scale;
    }
}