using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private CharacterController _CharacterController;

    private float _verticalVelocity = 0f;
    private Vector3 _direction = new();


    private void Update()
    {
        ApplyGravity();
        ApplyMovement();
    }

    public void Move(Vector2 p_input, float p_speed)
    {
        _direction = transform.right * p_input.x + transform.forward * p_input.y;

        _direction.x = _direction.x * p_speed;
        _direction.z = _direction.z * p_speed;
    }

    public void SetColliderHeight(float p_height)
    {
        _CharacterController.center = new Vector3(0, p_height / 2f, 0);
        _CharacterController.height = p_height;
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
}
