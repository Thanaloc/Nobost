using UnityEngine;

public class AIChaseState : IAIState
{
    private AISettingsSO _data;
    private Vector3 _lastKnownPlayerPos = new();

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
        _lastKnownPlayerPos = p_stateMachine.AIDetector.PlayerTransform.position;

        if (!p_stateMachine.AIDetector.IsPlayerDetected)
        {
            p_stateMachine.SetLastKnownPlayerPos(_lastKnownPlayerPos);
            p_stateMachine.TransitionTo(p_stateMachine.SearchState);
            return;
        }

        p_stateMachine.Agent.SetDestination(_lastKnownPlayerPos);

        if (Vector3.Distance(p_stateMachine.Agent.transform.position, _lastKnownPlayerPos) <= _data.CatchDistance)
        {
            if (p_stateMachine.CurrentState.Equals(p_stateMachine.PlayerCaughtState))
                return;

            p_stateMachine.AIDetector.OnPlayerCaught.Raise();
            p_stateMachine.TransitionTo(p_stateMachine.PlayerCaughtState);
        }
    }

    public void Exit(AIPatrolStateMachine p_stateMachine)
    {
        _lastKnownPlayerPos = new();
    }
}
