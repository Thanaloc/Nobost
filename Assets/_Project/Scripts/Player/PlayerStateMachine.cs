using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerMotor _Motor;
    [SerializeField] private PlayerInputHandler _InputHandler;

    [Header("State Data")]
    [SerializeField] private PlayerStateDataSO _IdleData;
    [SerializeField] private PlayerStateDataSO _WalkData;
    [SerializeField] private PlayerStateDataSO _CrouchData;
    [SerializeField] private PlayerStateDataSO _SprintData;

    public PlayerMotor Motor => _Motor;
    public PlayerInputHandler Input => _InputHandler;

    // Les états (instanciés dans Awake)
    // L'état courant
    // TransitionTo(IPlayerState p_newState)
    // Update() appelle _currentState.Execute(this)
}
