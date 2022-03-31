using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public PlayerControl _playerControl;
    private bool continueButtonPressed = false;
    private bool onTrigger = false;


    private void Awake()
    {
        _playerControl = new PlayerControl();
    }

    private void OnEnable()
    {
        _playerControl.Enable();
    }

    private void OnDisable()
    {
        _playerControl.Disable();
    }

    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(dialog);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            continueButtonPressed = false;
            onTrigger = true;
            TriggerDialog();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            onTrigger = false;
            FindObjectOfType<DialogManager>().EndDialog();
        }
    }


    private void Update()
    {
        if (_playerControl.Player.ContinueDialog.triggered)
        {
            continueButtonPressed = true;
        }

        if (onTrigger && continueButtonPressed)
        {
            FindObjectOfType<DialogManager>().DisplayNextSentence();
            continueButtonPressed = false;
        }
    }

}
