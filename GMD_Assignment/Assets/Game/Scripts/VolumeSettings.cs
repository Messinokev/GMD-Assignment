using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public bool alreadyFound = false;

    public void SetVolume(float volume)
    {
        float musicVolume = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat("volume", musicVolume);
        PlayerPrefs.SetFloat("Volume", volume);

        
        //Debug.Log("Volume: " + PlayerPrefs.GetFloat("Volume"));
    }

    private void Update()
    {
        if (!alreadyFound)
        {
            if (GameObject.Find("VolumeSlider"))
            {
                GameObject.Find("VolumeSlider").GetComponent<Slider>().value = PlayerPrefs.GetFloat("Volume");
                alreadyFound = true;
            }
        }
    }
}
