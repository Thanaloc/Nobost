using UnityEngine;

public class AISearchState : IAIState
{
    private PlayerStateDataSO _data;

    public AISearchState(PlayerStateDataSO p_data)
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
