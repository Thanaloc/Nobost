using UnityEngine;

public class AIDetection : MonoBehaviour
{
    public enum PlayerDetectionState
    {
        Detected,
        Lost
    }

    [SerializeField] private PlayerRefSO _PlayerRef;
    [SerializeField] private GameEvent _OnPlayerDetected;
    [SerializeField] private GameEvent _OnPlayerLost;
    [SerializeField] private GameEvent _OnPlayerCaught;

    private Transform _playerTransform;
    private AISettingsSO _settings;

    private bool _isInit = false;
    private bool _isPlayerDetected = false;

    private RaycastHit _raycastHit;

    private Vector3 _playerDirection = new();
    private Vector3 _eyePos = new();
    private Vector3 _playerCenter = new();
    private PlayerDetectionState _currentState = PlayerDetectionState.Lost;

    public bool IsPlayerDetected => _isPlayerDetected;
    public Transform PlayerTransform => _playerTransform;

    public GameEvent OnPlayerCaught => _OnPlayerCaught;

    public void Initialize(AISettingsSO p_settings)
    {
        _playerTransform = _PlayerRef.PlayerTransform;
        _settings = p_settings;
        _isInit = true;
    }

    private void Update()
    {
        if (!_isInit)
            return;

        _eyePos = transform.position + Vector3.up * 1.0f;
        _playerCenter = _playerTransform.position + Vector3.up * 1.0f;

        _playerDirection = (_playerCenter - _eyePos).normalized;

        if (Vector3.Distance(_eyePos, _playerCenter) <= _settings.DetectionRange &&
            Vector3.Angle(transform.forward, _playerDirection) <= _settings.DetectionAngle)
        {
            if (Physics.Raycast(_eyePos, _playerDirection, out _raycastHit, _settings.DetectionRange))
            {
                if (_raycastHit.transform == _playerTransform)
                {
                    if (_currentState == PlayerDetectionState.Lost)
                    {
                        _OnPlayerDetected.Raise();
                        _currentState = PlayerDetectionState.Detected;
                        _isPlayerDetected = true;
                    }

                }

                else
                {
                    if (_currentState == PlayerDetectionState.Detected)
                    {
                        _OnPlayerLost.Raise();
                        _currentState = PlayerDetectionState.Lost;
                        _isPlayerDetected = false;
                    }
                }
            }
        }

        else
        {
            if (_currentState == PlayerDetectionState.Detected)
            {
                _OnPlayerLost.Raise();
                _currentState = PlayerDetectionState.Lost;
                _isPlayerDetected = false;
            }
        }
    }

}
