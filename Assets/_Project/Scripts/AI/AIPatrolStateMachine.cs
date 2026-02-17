using System.Collections;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrolStateMachine : MonoBehaviour
{
    [SerializeField] private Transform[] _Waypoints;

    [SerializeField] private AISettingsSO _AIConfig;

    [SerializeField] private NavMeshAgent _Agent;
    [SerializeField] private AIDetection _AIDetection;

    public IAIState PatrolState => _patrolState;
    public IAIState ChaseState => _chaseState;
    public IAIState SearchState => _searchState;

    public NavMeshAgent Agent => _Agent;
    public AIDetection AIDetector => _AIDetection;

    public Transform[] Waypoints => _Waypoints;

    public Vector3 LastKnowPlayerPosition = new();

    private IAIState _currentState;
    private IAIState _patrolState;
    private IAIState _chaseState;
    private IAIState _searchState;

    private void Awake()
    {
        _patrolState = new AIPatrolState(_AIConfig);
        _searchState = new AISearchState(_AIConfig);
        _chaseState = new AIChaseState(_AIConfig);

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

    public void TransitionTo(IAIState p_newState)
    {
        if (p_newState.Equals(_currentState))
            return;

        _currentState.Exit(this);
        _currentState = p_newState;
        _currentState.Enter(this);
    }
}
