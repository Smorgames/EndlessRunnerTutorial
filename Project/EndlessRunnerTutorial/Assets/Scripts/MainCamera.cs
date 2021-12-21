using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private Animator _animator;
    
    private string _shakeCameraKey = "ShakeCamera";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ShakeCamera()
    {
        _animator.SetTrigger(_shakeCameraKey);
    }
}