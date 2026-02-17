using UnityEngine;

public class AIChaseState : IAIState
{
    private AISettingsSO _data;

    public AIChaseState(AISettingsSO p_data)
    {
        _data = p_data;
    }

    public void Enter(AIPatrolStateMachine p_stateMachine)
    {
        p_stateMachine.Agent.speed = _data.ChaseSpeed;
    }

    public void Execute(AIPatrolStateMachine p_stateMachine)
    {
        if (!p_stateMachine.AIDetector.IsPlayerDetected)
        {
            p_stateMachine.LastKnowPlayerPosition = p_stateMachine.AIDetector.PlayerTransform.position;
            p_stateMachine.TransitionTo(p_stateMachine.SearchState);
            return;
        }

        p_stateMachine.Agent.SetDestination(p_stateMachine.AIDetector.PlayerTransform.position);

    }

    public void Exit(AIPatrolStateMachine p_stateMachine)
    {

    }
}
