using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController _characterController;

    private float _verticalVelocity = 0f;
    private Vector3 _direction = new();

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        ApplyGravity();
    }

    public void Move(Vector2 p_input, float p_speed)
    {
        _direction = transform.right * p_input.x + transform.forward * p_input.y;
        _direction.y = _verticalVelocity;

        _characterController.Move(_direction * p_speed * Time.deltaTime);
    }

    public void SetColliderHeight(float p_height)
    {
        _characterController.center = new Vector3(0, p_height / 2f, 0);
    }

    public bool IsGrounded()
    {
        return _characterController.isGrounded;
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _verticalVelocity > 0)
            _verticalVelocity = -1f;
        else
            _verticalVelocity += Physics.gravity.y * Time.deltaTime;
    }
}
