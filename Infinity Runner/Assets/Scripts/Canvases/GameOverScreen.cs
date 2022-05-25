using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player.DieEvent += OnDie;
        _restartButton.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnDisable()
    {
        _player.DieEvent -= OnDie;
    }

    private void OnDie()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }
}
