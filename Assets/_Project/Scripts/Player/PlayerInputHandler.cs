using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset _InputActions;

    public Vector2 MoveInput { get; private set; }
    public Vector2 LookInput { get; private set; }
    public bool SprintPressed { get; private set; }
    public bool CrouchPressed { get; private set; }
    public bool JumpPressed { get; private set; }

    // Awake : instancier _inputActions
    // OnEnable : activer et s'abonner
    // OnDisable : désabonner et désactiver
    // les callbacks mettent à jour les properties
}