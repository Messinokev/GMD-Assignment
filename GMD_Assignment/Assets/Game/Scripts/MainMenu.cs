using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        if (GameObject.Find("PauseCanvas"))
        {
            GameObject.Find("PauseCanvas").GetComponentInChildren<PauseMenu>().Resume();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("AtMine", 0);
        PlayerPrefs.SetInt("Coins", 0);
        PlayerPrefs.SetInt("PickedEgg", 0);
        PlayerPrefs.SetInt("PickedLogs", 0);
        PlayerPrefs.SetInt("Quest", 0);

        string path = Application.persistentDataPath + "/saveData.save";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        SceneManager.LoadScene(1);
    }
}
