using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryHandler : MonoBehaviour
{
    [SerializeField] private GameStateSO _GameState;
    [SerializeField] private GameObject _CanvasVictory;
    [SerializeField] private GameEvent _VictoryGameEvent;

    private bool _isVictory = false;

    private void OnEnable()
    {
        _GameState.OnStateChanged += OnNewState;
    }

    private void OnDisable()
    {
        _GameState.OnStateChanged -= OnNewState;
    }

    private void OnNewState(GameStateSO.GameState p_newState)
    {
        if (p_newState.Equals(GameStateSO.GameState.Victory))
        {
            _CanvasVictory.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            _isVictory = true;
        }
    }

    private void Update()
    {
        if (_isVictory && Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
            _isVictory = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider p_other)
    {
        _VictoryGameEvent.Raise();
    }
}
