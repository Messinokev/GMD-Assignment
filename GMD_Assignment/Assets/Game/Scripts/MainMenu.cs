using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        if (PlayerPrefs.GetInt("AtMine") == 1)
        {
            transform.position = new Vector3(19.4593678f, -4.46455145f, 0);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
