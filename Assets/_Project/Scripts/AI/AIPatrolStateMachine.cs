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

    private IAIState _currentState;
    private IAIState _patrolState;
    private IAIState _chaseState;
    private IAIState _searchState;

    private IEnumerator _agentCoroutine;

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
        _Agent.speed = _AIConfig.PatrolSpeed;
        _agentCoroutine = AgentMoveRoutine();
        StartCoroutine(_agentCoroutine);
    }
    private void Update()
    {
        _currentState.Execute(this);
    }

    private IEnumerator AgentMoveRoutine()
    {
        int i = 0;
        while (true)
        {
            _Agent.SetDestination(_Waypoints[i].position);

            yield return null;

            while (_Agent.pathPending || _Agent.remainingDistance > 0.2f)
                yield return null;

            yield return new WaitForSeconds(_AIConfig.WaitTime);

            i = (i + 1) % _Waypoints.Length;
        }
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
