using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    [SerializeField] private int nextSceneToLoad = 1;

    public PlayerControl _playerControl;
    private bool atEntrance;


    private void Awake()
    {
        _playerControl = new PlayerControl();
        atEntrance = false;
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

        if (atEntrance && upArrowPressed)
        {
            if (nextSceneToLoad == 1)
            {
                PlayerPrefs.SetInt("AtMine", 1);
            }
            SceneManager.LoadScene(nextSceneToLoad);
            //GameObject.Find("Respawn").GetComponent<Respawn>().checkForPickables();
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
