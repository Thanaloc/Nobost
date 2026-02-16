using UnityEngine;

public class PlayerCrouchState : IPlayerState
{
    private PlayerStateDataSO _data;

    public PlayerCrouchState(PlayerStateDataSO p_data)
    {
        _data = p_data;
    }

    public void Enter(PlayerStateMachine p_stateMachine)
    {

    }

    public void Execute(PlayerStateMachine p_stateMachine)
    {

    }

    public void Exit(PlayerStateMachine p_stateMachine)
    {

    }
}
