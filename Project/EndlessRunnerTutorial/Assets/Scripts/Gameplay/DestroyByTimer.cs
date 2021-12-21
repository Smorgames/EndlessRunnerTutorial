using UnityEngine;

public class DestroyByTimer : MonoBehaviour
{
    private static float _destroyTime = 5f;
    
    private void Start() => Destroy(gameObject, _destroyTime);
}