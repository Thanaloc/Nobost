using System.Collections;
using UnityEngine;

public class AIPatrolState : IAIState
{
    private AISettingsSO _data;

    private IEnumerator _agentMoveCoroutine;

    public AIPatrolState(AISettingsSO p_data)
    {
        _data = p_data;
    }

    public void Enter(AIPatrolStateMachine p_stateMachine)
    {
        p_stateMachine.Agent.speed = _data.PatrolSpeed;

        if (_agentMoveCoroutine == null)
        {
            _agentMoveCoroutine = AgentMoveRoutine(p_stateMachine);
            p_stateMachine.StartCoroutine(_agentMoveCoroutine);
        }
    }

    public void Execute(AIPatrolStateMachine p_stateMachine)
    {
        if (p_stateMachine.AIDetector.IsPlayerDetected)
        {
            p_stateMachine.TransitionTo(p_stateMachine.ChaseState);
            return;
        }
    }

    private IEnumerator AgentMoveRoutine(AIPatrolStateMachine p_patrolStateMachine)
    {
        int i = 0;
        while (true)
        {
            p_patrolStateMachine.Agent.SetDestination(p_patrolStateMachine.Waypoints[i].position);

            yield return null;

            while (p_patrolStateMachine.Agent.pathPending || p_patrolStateMachine.Agent.remainingDistance > 0.2f)
                yield return null;

            yield return new WaitForSeconds(_data.WaitTime);

            i = (i + 1) % p_patrolStateMachine.Waypoints.Length;
        }
    }

    public void Exit(AIPatrolStateMachine p_stateMachine)
    {
        if (_agentMoveCoroutine != null)
        {
            p_stateMachine.StopCoroutine(_agentMoveCoroutine);
            _agentMoveCoroutine = null;
        }

    }
}
