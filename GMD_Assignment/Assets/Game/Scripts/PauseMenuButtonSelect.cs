using UnityEngine;
using UnityEngine.UI;

public class PauseMenuButtonSelect : MonoBehaviour
{
    public Button resumeButton;
    public bool resumeButtonSelected = true;
    public Button backButton;
    private bool backButtonSelected = true;

    void Update()
    {
        if (GameObject.Find("PauseMenu") && resumeButtonSelected)
        {
            resumeButton.Select();
            resumeButtonSelected = false;
            backButtonSelected = true;

        }
        if (GameObject.Find("ControlsMenu") && backButtonSelected)
        {
            backButton.Select();
            resumeButtonSelected = true;
            backButtonSelected = false;
        }
    }
}
