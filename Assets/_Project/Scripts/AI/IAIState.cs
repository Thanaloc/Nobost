using UnityEngine;

public interface IAIState 
{
    void Enter(AIPatrolStateMachine p_stateMachine);
    void Execute(AIPatrolStateMachine p_stateMachine);
    void Exit(AIPatrolStateMachine p_stateMachine);
}
