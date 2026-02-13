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

    private GameState _currentState;

    public GameState CurrentState => _currentState;
    public Event OnStateChanged;

    public void SetState(GameState p_newState)
    {
        _currentState = p_newState;
    }
}
