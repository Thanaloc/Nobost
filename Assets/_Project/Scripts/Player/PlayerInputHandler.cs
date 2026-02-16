using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private InputSystem_Actions _inputActions;

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool SprintPressed { get; private set; }
    public bool CrouchPressed { get; private set; }
    public bool JumpPressed { get; private set; }

    // Awake : instancier _inputActions
    // OnEnable : activer et s'abonner
    // OnDisable : désabonner et désactiver
    // les callbacks mettent à jour les properties

    private void Awake()
    {
        _inputActions = new();
    }

    private void OnEnable()
    {
        _inputActions.Enable();

        //Move
        _inputActions.Player.Move.performed += context => MoveInput = context.ReadValue<Vector2>();
        _inputActions.Player.Move.canceled += context => MoveInput = Vector2.zero;

        //Look
        _inputActions.Player.Look.performed += context => LookInput = context.ReadValue<Vector2>();
        _inputActions.Player.Look.canceled += context => LookInput = Vector2.zero;

        //sprint
        _inputActions.Player.Sprint.performed += context => SprintPressed = true;
        _inputActions.Player.Sprint.canceled += context => SprintPressed = false;

        //crouch
        _inputActions.Player.Crouch.performed += context => CrouchPressed = true;
        _inputActions.Player.Crouch.canceled += context => CrouchPressed = false;

        //Jump
        _inputActions.Player.Jump.performed += context => JumpPressed = true;
        _inputActions.Player.Jump.canceled += context => JumpPressed = false;

    }

    private void OnDisable()
    {
        _inputActions.Player.Disable();
    }

}