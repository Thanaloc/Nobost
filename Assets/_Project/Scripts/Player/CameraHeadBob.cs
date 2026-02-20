using UnityEngine;

public class CameraHeadBob : MonoBehaviour
{
    [SerializeField] private CharacterController _CharacterController;
    [SerializeField] private Transform _CameraHolder;
    [SerializeField] private PlayerRefSO _Player;
    [SerializeField] private PlayerStateMachine _PlayerStateMachine;

    private float _timer = 0f;
    private float _bobOffset = 0f;
    private float _currentBobFrequency = 0f;
    private float _currentBobAmplitude = 0f;

    public float BobOffset => _bobOffset;

    private const float LERP_INTERPOLATION = 5f;

    private void Start()
    {
        OnPlayerStateChanged();
    }

    private void Update()
    {
        if (_CharacterController.velocity.sqrMagnitude > .1f)
        {
            _timer += Time.deltaTime;
            _bobOffset = Mathf.Sin(_timer * _currentBobFrequency) * _currentBobAmplitude;
        }

        else
        {
            _bobOffset = Mathf.Lerp(_bobOffset, 0f, LERP_INTERPOLATION * Time.deltaTime);
            _timer = 0f;
        }
    }

    //called by response of game event "OnPlayerStateChanged" inspector
    public void OnPlayerStateChanged()
    {
        _currentBobAmplitude = _PlayerStateMachine.CurrentState.GetBobAmplitude();
        _currentBobFrequency = _PlayerStateMachine.CurrentState.GetBobFrequency();
    }
}
