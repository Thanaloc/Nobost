using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private CharacterController _CharacterController;
    [SerializeField] private Camera _Camera;
    [SerializeField] private Transform _CameraHolder;
    [SerializeField] private PlayerRefSO _PlayerRef;

    private float _verticalVelocity = 0f;
    private Vector3 _direction = new();
    private const float LERP_INTERPOLATION = 10f;
    private Vector3 _targetHeight = new();
    private float _targetFOV = 0f;
    private float _defaultFOV = 0f;

    private bool _isSprinting = false;

    private void Awake()
    {
        _PlayerRef.PlayerTransform = transform;
        _targetHeight = _CameraHolder.localPosition;
        _targetFOV = _Camera.fieldOfView;
        _defaultFOV = _Camera.fieldOfView;
    }

    private void OnDisable()
    {
        _PlayerRef.PlayerTransform = null;
    }

    private void Update()
    {
        ApplyTargetFOV();
        ApplyCameraHeight();
        ApplyGravity();
        ApplyMovement();
    }

    public void Move(Vector2 p_input, float p_speed)
    {
        _direction = transform.right * p_input.x + transform.forward * p_input.y;

        _direction.x *= p_speed;
        _direction.z *= p_speed;
    }

    public void SetColliderHeight(float p_height)
    {
        _CharacterController.center = new Vector3(0, p_height / 2f, 0);
        _CharacterController.height = p_height;
    }

    public void SetCameraHeight(float p_height)
    {
        _targetHeight = new Vector3(0, p_height, 0);
    }

    public void SetTargetFOV(bool p_isSprinting)
    {
        if (p_isSprinting)
        {
            _targetFOV = _defaultFOV + _defaultFOV * _PlayerRef.SprintFOVMultiplier;
        }

        else 
        {
            _targetFOV = _defaultFOV;
        }
    }

    public bool IsGrounded()
    {
        return _CharacterController.isGrounded;
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _verticalVelocity < 0)
            _verticalVelocity = -1f;
        else
            _verticalVelocity += Physics.gravity.y * Time.deltaTime;

        _direction.y = _verticalVelocity;
    }

    private void ApplyMovement()
    {
        _CharacterController.Move(_direction * Time.deltaTime);
        _direction.x = _direction.z = 0f;
    }

    private void ApplyCameraHeight()
    {
        _CameraHolder.localPosition = Vector3.Lerp(_CameraHolder.localPosition, _targetHeight, LERP_INTERPOLATION * Time.deltaTime);
    }

    private void ApplyTargetFOV()
    {
        _Camera.fieldOfView = Mathf.Lerp(_Camera.fieldOfView, _targetFOV, LERP_INTERPOLATION * Time.deltaTime);
    }

}
