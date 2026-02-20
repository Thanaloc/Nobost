using UnityEngine;

public class CameraHeadBob : MonoBehaviour
{
    [SerializeField] private CharacterController _CharacterController;
    [SerializeField] private Transform _CameraHolder;
    [SerializeField] private PlayerRefSO _Player;

    private float _timer = 0f;
    private float _bobOffset = 0f;

    public float BobOffset => _bobOffset;

    private const float LERP_INTERPOLATION = 5f;

    private void Update()
    {
        if (_CharacterController.velocity.sqrMagnitude > .1f)
        {
            _timer += Time.deltaTime;
            _bobOffset = Mathf.Sin(_timer * _Player.BobFrequency) * _Player.BobAmplitude;
        }

        else
        {
            _bobOffset = Mathf.Lerp(_bobOffset, 0f, LERP_INTERPOLATION * Time.deltaTime);
            _timer = 0f;
        }
    }
}
