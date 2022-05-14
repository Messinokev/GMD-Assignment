using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private int nextSceneToLoad = 1;
    public PlayerControl _playerControl;
    private PlayerInput _playerInput;
    private bool atEntrance;

    private void Awake()
    {
        _playerControl = new PlayerControl();
        atEntrance = false;
        _playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
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
        if (!_playerInput)
        {
            _playerInput = GameObject.Find("Player").GetComponent<PlayerInput>();
        }

        if (atEntrance && _playerInput.actions["SceneLoad"].ReadValue<float>() > 0)
        {
            if (nextSceneToLoad == 2)
            {
                PlayerPrefs.SetInt("AtMine", 1);
            } 
            SceneManager.LoadScene(nextSceneToLoad);
            GameObject.Find("Volume").GetComponent<VolumeSettings>().alreadyFound = false;
            GameObject.Find("Player").GetComponent<PlayerController>().canJump = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            atEntrance = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            atEntrance = false;
        }
    }
}
