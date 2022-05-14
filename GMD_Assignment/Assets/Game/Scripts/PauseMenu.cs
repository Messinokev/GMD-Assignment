using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    private PlayerControl _playerControl;
    private PlayerInput _playerInput;
    public GameObject pauseMenuUI;
    public GameObject menuUI;
    public GameObject controlsMenu;

    private void Awake()
    {
        _playerControl = new PlayerControl();
        _playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerControl.UI.Enable();
    }

    private void OnDisable()
    {
        _playerControl.UI.Disable();
    }

    public void Update()
    {
        if (!_playerInput)
        {
            _playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        }

        if (_playerControl.UI.PauseGame.triggered)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        GameObject.Find("PauseCanvas").GetComponent<PauseMenuButtonSelect>().resumeButtonSelected = true;

        _playerInput.actions.FindActionMap("Player").Enable();
        _playerInput.actions.FindActionMap("UI").Disable();
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        menuUI.SetActive(true);
        controlsMenu.SetActive(false);

        Time.timeScale = 0f;
        GameIsPaused = true;

        _playerInput.actions.FindActionMap("UI").Enable();
        _playerInput.actions.FindActionMap("Player").Disable();
    }

    public void LoadMenu()
    {
        Destroy(GameObject.Find("PauseCanvas"));
        SceneManager.LoadScene(0);
    }
}
