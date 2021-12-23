using UnityEngine;

public class MouseController : MonoBehaviour
{
    private float _counter;
    private float _timeBeforeHideCursor = 1f;

    private Vector3 _lastMousePosition;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (_lastMousePosition != Input.mousePosition)
        {
            _lastMousePosition = Input.mousePosition;
            Cursor.visible = true;
            _counter = 0f;
        }
        else
        {
            _counter += Time.deltaTime;

            if (_counter >= _timeBeforeHideCursor) 
                Cursor.visible = false;
        }
    }
}