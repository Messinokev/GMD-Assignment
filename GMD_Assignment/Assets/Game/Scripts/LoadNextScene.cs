using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private int nextSceneToLoad = 1;

    public PlayerControl _playerControl;
    private bool atMine;



    private void Awake()
    {
        _playerControl = new PlayerControl();
        atMine = false;
    }

    private void OnEnable()
    {
        _playerControl.Enable();
    }

    private void OnDisable()
    {
        _playerControl.Disable();
    }

    private void Update()
    {
        bool upArrowPressed = _playerControl.Player.SceneLoad.triggered;

        if (atMine && upArrowPressed)
        {
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            atMine = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            atMine = false;
        }
    }
}
