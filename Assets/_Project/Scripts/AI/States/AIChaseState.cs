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

    }

    public void Execute(AIPatrolStateMachine p_stateMachine)
    {
        

    }

    public void Exit(AIPatrolStateMachine p_stateMachine)
    {

    }
}
