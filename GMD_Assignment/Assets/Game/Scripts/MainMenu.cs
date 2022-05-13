using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    private void Start()
    {
        float musicVolume = Mathf.Log10(PlayerPrefs.GetFloat("Volume")) * 20;
        audioMixer.SetFloat("volume", musicVolume);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        if (PlayerPrefs.GetInt("AtMine") == 1)
        {
            transform.position = new Vector3(19.4593678f, -4.46455145f, 0);
        }
        if (GameObject.Find("PauseCanvas"))
        {
            GameObject.Find("PauseCanvas").GetComponent<PauseMenu>().GameIsPaused = false;
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
        Time.timeScale = 1f;
        if (GameObject.Find("PauseCanvas"))
        {
            GameObject.Find("PauseCanvas").GetComponent<PauseMenu>().GameIsPaused = false;
        }
        if (GameObject.Find("Health bar"))
        {
            GameObject.Find("Health bar").GetComponent<HealthBar>().currentHealth = 100;
            GameObject.Find("Health bar").GetComponent<HealthBar>().SetHealth(100);
            GameObject.Find("Potion").GetComponent<HealthPotion>().potionCount = 1;
            GameObject.Find("Potion").GetComponent<HealthPotion>().SetPotionCountText();
        }
    }
}
