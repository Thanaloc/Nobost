using UnityEngine;

public class AIDetection : MonoBehaviour
{
    [SerializeField] private PlayerRefSO _PlayerRef;

    private Transform _playerTransform;
    private AISettingsSO _settings;

    private bool _isInit = false;

    private RaycastHit _raycastHit;
    private LayerMask _playerLayerMask;


    public void Initialize(AISettingsSO p_settings)
    {
        _playerTransform = _PlayerRef.PlayerTransform;
        _settings = p_settings;
        _playerLayerMask = LayerMask.GetMask("Player");
        _isInit = true;
    }

    private void Update()
    {
        if (!_isInit)
            return;

        if (Vector3.Distance(transform.position, _playerTransform.position) <= _settings.DetectionRange && 
            Vector3.Angle(transform.forward, _playerTransform.position) <= _settings.DetectionAngle)
        {
            if (Physics.Raycast(transform.position, transform.forward, out _raycastHit, Mathf.Infinity, _playerLayerMask))

            {
                Debug.DrawRay(transform.position, transform.forward * _raycastHit.distance, Color.yellow);
                Debug.Log("Did Hit player");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.forward * 1000, Color.white);
                Debug.Log("Did not Hit player");
            }
        }
    }
}
