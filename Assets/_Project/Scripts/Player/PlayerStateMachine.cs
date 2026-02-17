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

    public IPlayerState IdleState => _idleState;
    public IPlayerState WalkState => _walkState;
    public IPlayerState CrouchState => _crouchState;
    public IPlayerState SprintState => _sprintState;
    public IPlayerState CurrentState => _currentState;  

    private IPlayerState _currentState;
    private IPlayerState _idleState;
    private IPlayerState _walkState;
    private IPlayerState _crouchState;
    private IPlayerState _sprintState;

    private void Awake()
    {
        _idleState = new PlayerIdleState(_IdleData);
        _walkState = new PlayerWalkState(_WalkData);
        _crouchState = new PlayerCrouchState(_CrouchData);
        _sprintState = new PlayerSprintState(_SprintData);

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
