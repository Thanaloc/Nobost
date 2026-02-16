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

    public IPlayerState IdleState;
    public IPlayerState WalkState;
    public IPlayerState CrouchState;
    public IPlayerState SprintState;

    private IPlayerState _currentState;

    private void Awake()
    {
        IdleState = new PlayerIdleState(_IdleData);
        WalkState = new PlayerWalkState(_WalkData);
        CrouchState = new PlayerCrouchState(_CrouchData);
        SprintState = new PlayerSprintState(_SprintData);

        _currentState = IdleState;
        _currentState.Enter(this);
    }

    private void Update()
    {
        _currentState.Execute(this);
    }

    public void TransitionTo(IPlayerState p_newState)
    {
        if (p_newState.Equals(_currentState))
            return;

        _currentState.Exit(this);
        _currentState = p_newState;
        _currentState.Enter(this);
    }

}
