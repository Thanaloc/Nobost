using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameStateSO _GameState;
    [SerializeField] private GameObject _CanvasGameOver;

    private bool _isGameOver = false;

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
        if (p_newState.Equals(GameStateSO.GameState.GameOver))
        {
            _CanvasGameOver.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            _isGameOver = true;
        }
    }

    private void Update()
    {
        if (_isGameOver && Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 1;
            _isGameOver = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
