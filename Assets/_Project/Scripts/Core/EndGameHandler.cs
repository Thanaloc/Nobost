using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] private GameStateSO _GameState;
    [SerializeField] private GameObject _CanvasGameOver;
    [SerializeField] private GameObject _CanvasVictory;

    private bool _isEndGame = false;

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
        switch (p_newState)
        {
            case GameStateSO.GameState.GameOver:
                _CanvasGameOver.SetActive(true);
                _isEndGame = true;
                break;

            case GameStateSO.GameState.Victory:
                _CanvasVictory.SetActive(true);
                _isEndGame = true;
                break;
        }

        if (_isEndGame)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        if (_isEndGame && Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
            _isEndGame = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
