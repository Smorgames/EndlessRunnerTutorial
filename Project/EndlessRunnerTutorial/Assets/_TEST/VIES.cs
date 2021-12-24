using System.Collections;
using TMPro;
using UnityEngine;

public class VIES : MonoBehaviour
{
    [SerializeField] private LineRenderer _moveOffset_Line;
    [Space]
    [SerializeField] private Transform _rocket;
    [SerializeField] private Transform _leftGhostRocket;
    [SerializeField] private Transform _rightGhostRocket;
    [Space]
    [SerializeField] private Camera _mainCamera;
    [Space] 
    [SerializeField] private Transform _moveOffset_Canvas;
    [SerializeField] private TextMeshProUGUI _moveOffset_TMP;
    [Space] 
    [SerializeField] private Transform _leftArrow;
    [SerializeField] private Transform _rightArrow;
    [Space] 
    [SerializeField] private Transform _targetPositionObject;

    private Vector3 _targetPosition => _targetPositionObject.position;
    private Vector3 _zMouseOffset = new Vector3(0f, 0f, 10f);
    
    private float _counter;
    private float _animationSpeed = 3f;
    
    private bool _startLoopMovement;

    private bool _startMoveToCorrectMoveOffset;
    private Vector3 _startPos;
    

    // Properties
    private Vector3 _screenBasedMousePos => _mainCamera.ScreenToWorldPoint(Input.mousePosition) + _zMouseOffset;
    private Vector3 _horizontalScreenBasedMousePos => new Vector3(_screenBasedMousePos.x, 0f, 0f);
    
    private void Start()
    {
        _targetPositionObject.position = _rocket.position + Vector3.right * 3;
        _moveOffset_Line.SetPosition(0, _rocket.position);
        _moveOffset_Line.SetPosition(1, _targetPosition);
    }

    private void Update() 
    {
        _moveOffset_Line.SetPosition(1, _targetPosition);
        SetGhostRocketsPositions();
        SetMoveOffsetText();
        SetArrowsPosition();
        
        if (Input.GetKeyDown(KeyCode.S))
            EndLoopMovement();
        if (Input.GetKeyDown(KeyCode.Alpha1))
            StartLoopMovement();
        if (Input.GetKeyDown(KeyCode.Alpha2))
            StartMoveToCorrectMoveOffset();
        
        LoopMovement();
        MoveToCorrectMoveOffset();
    }

    private void SetArrowsPosition()
    {
        _leftArrow.position = _rocket.position;
        _rightArrow.position = _targetPosition;
    }

    private void SetMoveOffsetText()
    {
        var canvasPos = _targetPosition / 2;
        _moveOffset_Canvas.position = canvasPos;
        var moveOffset = Vector2.Distance(_rocket.position, _targetPosition);
        _moveOffset_TMP.text = $"MoveOffset = {moveOffset:0.00}";
    }

    private void SetGhostRocketsPositions()
    {
        var leftGhostRocketPos = -_targetPosition;
        _leftGhostRocket.position = leftGhostRocketPos;
        _rightGhostRocket.position = _targetPosition;
    }

    private void StartLoopMovement() => _startLoopMovement = true;
    private void EndLoopMovement()
    {
        _counter = 0f;
        _startLoopMovement = false;
    }
    private void LoopMovement()
    {
        if (!_startLoopMovement) return;

        var startPos = new Vector3(3f, 0f, 0f);
        var endPos = new Vector3(10f, 0f, 0f);
        var t = Mathf.Abs(Mathf.Sin(_counter));
        _targetPositionObject.position = Vector3.Lerp(startPos, endPos, t);
        _counter += Time.deltaTime / _animationSpeed;
    }

    private void StartMoveToCorrectMoveOffset()
    {
        EndLoopMovement();
        _startPos = _targetPosition;
        _startMoveToCorrectMoveOffset = true;
    }

    private void MoveToCorrectMoveOffset()
    {
        if (!_startMoveToCorrectMoveOffset) return;
        
        var endPos = new Vector3(2f, 0f, 0f);
        var t = _counter;
        _targetPositionObject.position = Vector3.Lerp(_startPos, endPos, t);
        _counter += Time.deltaTime / _animationSpeed;

        if (t >= 1f)
            _startMoveToCorrectMoveOffset = false;
    }
} 