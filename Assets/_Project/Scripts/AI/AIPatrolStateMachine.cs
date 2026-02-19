using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolStateMachine : MonoBehaviour
{
    [SerializeField] private Transform[] _Waypoints;

    [SerializeField] private AISettingsSO _AIConfig;

    [SerializeField] private NavMeshAgent _Agent;
    [SerializeField] private AIDetection _AIDetection;
    [SerializeField] private AIHearing _AIHearing;

    public IAIState PatrolState => _patrolState;
    public IAIState ChaseState => _chaseState;
    public IAIState SearchState => _searchState;
    public IAIState PlayerCaughtState => _playerCaughtState;
    public IAIState CurrentState => _currentState;

    public NavMeshAgent Agent => _Agent;
    public AIDetection AIDetector => _AIDetection;
    public AIHearing AIHearer => _AIHearing;

    public Transform[] Waypoints => _Waypoints;

    public Vector3 LastKnowPlayerPosition => _lastKnownPlayerPosition;
    public Vector3 LastKnownSoundPosition => _lastKnownSoundPosition;

    private IAIState _currentState;
    private IAIState _patrolState;
    private IAIState _chaseState;
    private IAIState _searchState;
    private IAIState _playerCaughtState;

    private Vector3 _lastKnownPlayerPosition = new();
    private Vector3 _lastKnownSoundPosition = new();

    private void Awake()
    {
        _patrolState = new AIPatrolState(_AIConfig);
        _searchState = new AISearchState(_AIConfig);
        _chaseState = new AIChaseState(_AIConfig);
        _playerCaughtState = new AIPlayerCaughtState(_AIConfig);

        _currentState = PatrolState;
        _currentState.Enter(this);
    }

    private void Start()
    {
        _AIDetection.Initialize(_AIConfig);
    }
    private void Update()
    {
        _currentState.Execute(this);
    }

    public void SetLastKnownPlayerPos(Vector3 p_pos)
    {
        _lastKnownPlayerPosition = p_pos;
    }

    public void TransitionTo(IAIState p_newState)
    {
        if (p_newState.Equals(_currentState))
            return;

        _currentState.Exit(this);
        _currentState = p_newState;
        _currentState.Enter(this);
    }
}
