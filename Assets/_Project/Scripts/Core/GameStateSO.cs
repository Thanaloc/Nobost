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
        GameOver,
        Victory
    }

    private GameState _currentState = GameState.Playing;

    public GameState CurrentState => _currentState;
    public Action<GameState> OnStateChanged;

    private void OnEnable()
    {
        _currentState = GameState.Playing;
    }

    public void SetState(GameState p_newState)
    {
        if (_currentState == p_newState)
            return;

        _currentState = p_newState;
        OnStateChanged?.Invoke(_currentState);
    }
}
