using UnityEngine;

public interface IPlayerState 
{
    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
