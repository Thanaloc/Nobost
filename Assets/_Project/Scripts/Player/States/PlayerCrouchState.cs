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
        p_stateMachine.Motor.SetColliderHeight(_data.ColliderHeight);
        p_stateMachine.Motor.SetCameraHeight(_data.CameraHeight);

    }

    public void Execute(PlayerStateMachine p_stateMachine)
    {
        if (!p_stateMachine.Input.CrouchPressed && p_stateMachine.Input.MoveInput.sqrMagnitude == 0)
        {
            p_stateMachine.TransitionTo(p_stateMachine.IdleState);
            return;
        }

        if (!p_stateMachine.Input.CrouchPressed && p_stateMachine.Input.MoveInput.sqrMagnitude > 0.1f && p_stateMachine.Input.SprintPressed)
        {
            p_stateMachine.TransitionTo(p_stateMachine.SprintState);
            return;
        }

        if (!p_stateMachine.Input.CrouchPressed && p_stateMachine.Input.MoveInput.sqrMagnitude > 0.1f)
        {
            p_stateMachine.TransitionTo(p_stateMachine.WalkState);
            return;
        }

        p_stateMachine.Motor.Move(p_stateMachine.Input.MoveInput, _data.MoveSpeed);
    }

    public void Exit(PlayerStateMachine p_stateMachine)
    {

    }

    public float GetNoiseMultiplier()
    {
        return _data.NoiseMultiplier;
    }
}
