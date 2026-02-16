using System;
using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    private PlayerStateDataSO _data;

    public PlayerIdleState(PlayerStateDataSO p_data)
    {
        _data = p_data;
    }

    public void Enter(PlayerStateMachine p_stateMachine)
    {
        p_stateMachine.Motor.SetColliderHeight(_data.ColliderHeight);
    }

    public void Execute(PlayerStateMachine p_stateMachine)
    {
        if (p_stateMachine.Input.CrouchPressed)
        {
            p_stateMachine.TransitionTo(p_stateMachine.CrouchState);
        }

        if (p_stateMachine.Input.MoveInput.sqrMagnitude > .1f)
        {
            p_stateMachine.TransitionTo(p_stateMachine.WalkState);
        }

        else if (p_stateMachine.Input.MoveInput.sqrMagnitude > .1f && p_stateMachine.Input.SprintPressed)
        {
            p_stateMachine.TransitionTo(p_stateMachine.SprintState);
        }

    }

    public void Exit(PlayerStateMachine p_stateMachine)
    {

    }
}
