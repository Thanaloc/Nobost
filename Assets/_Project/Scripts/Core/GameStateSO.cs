using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Core/GameStateSO")]
public class GameStateSO : ScriptableObject
{
    public enum GameState
    {
        Menu,
        Playing,
        Paused,
        GameOver
    }

    private GameState _currentState = GameState.Playing;

    public GameState CurrentState => _currentState;
    public Action<GameState> OnStateChanged;

    public void SetState(GameState p_newState)
    {
        if (_currentState == p_newState)
            return;

        _currentState = p_newState;
        OnStateChanged?.Invoke(_currentState);
    }
}
