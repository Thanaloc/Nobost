using UnityEngine;

public class AIPatrolState : IAIState
{
    private AISettingsSO _data;

    public AIPatrolState(AISettingsSO p_data)
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
