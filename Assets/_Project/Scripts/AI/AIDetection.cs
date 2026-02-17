using UnityEngine;

public class AIDetection : MonoBehaviour
{
    [SerializeField] private PlayerRefSO _PlayerRef;

    private Transform _playerTransform;
    private AISettingsSO _settings;

    private bool _isInit = false;

    private RaycastHit _raycastHit;

    private Vector3 _playerDirection = new();
    private Vector3 _eyePos = new();
    private Vector3 _playerCenter = new();


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
                    Debug.Log("Did Hit player");
                }
            }
        }
    }
}
