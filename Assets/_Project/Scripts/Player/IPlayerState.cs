using UnityEngine;

public interface IPlayerState 
{
    void Enter(PlayerStateMachine p_stateMachine);
    void Execute(PlayerStateMachine p_stateMachine);
    void Exit(PlayerStateMachine p_stateMachine);
    float GetNoiseMultiplier();
    float GetBobAmplitude();
    float GetBobFrequency();
}
