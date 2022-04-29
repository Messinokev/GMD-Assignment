using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
    public Button playButton;
    private bool playButtonSelected = true;
    public Button noButton;
    private bool noButtonSelected = true;
    public Button controlsButton;
    private bool controlsButtonSelected = true;
    public Button backButton;
    private bool backButtonSelected = true;


    void Update()
    {
        if (GameObject.Find("MainMenu") && playButtonSelected)
        {
            playButton.Select();
            playButtonSelected = false;
            noButtonSelected = true;
            controlsButtonSelected = true;
            backButtonSelected = true;

        }
        if (GameObject.Find("NewGameMenu") && noButtonSelected)
        {
            noButton.Select();
            playButtonSelected = true;
            noButtonSelected = false;
            controlsButtonSelected = true;
            backButtonSelected = true;
        }
        if (GameObject.Find("OptionsMenu") && controlsButtonSelected)
        {
            controlsButton.Select();
            playButtonSelected = true;
            noButtonSelected = true;
            controlsButtonSelected = false;
            backButtonSelected = true;
        }
        if (GameObject.Find("ControlsMenu") && backButtonSelected)
        {
            backButton.Select();
            playButtonSelected = true;
            noButtonSelected = true;
            controlsButtonSelected = true;
            backButtonSelected = false;
        }
    }
}
