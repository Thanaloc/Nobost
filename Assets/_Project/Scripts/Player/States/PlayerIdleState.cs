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
        p_stateMachine.Motor.SetCameraHeight(_data.CameraHeight);
    }

    public void Execute(PlayerStateMachine p_stateMachine)
    {
        if (p_stateMachine.Input.CrouchPressed)
        {
            p_stateMachine.TransitionTo(p_stateMachine.CrouchState);
            return;
        }

        if (p_stateMachine.Input.SprintPressed)
        {
            p_stateMachine.TransitionTo(p_stateMachine.SprintState);
            return;
        }

        if (p_stateMachine.Input.MoveInput.sqrMagnitude > .1f)
        {
            p_stateMachine.TransitionTo(p_stateMachine.WalkState);
            return;
        }

    }

    public void Exit(PlayerStateMachine p_stateMachine)
    {

    }
}
