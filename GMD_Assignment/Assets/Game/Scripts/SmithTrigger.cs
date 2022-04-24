using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmithTrigger : MonoBehaviour
{
    public Dialog dialog;
    public PlayerControl _playerControl;
    private bool continueButtonPressed = false;
    private bool onTrigger = false;

    public bool logsPickedUp = false;

    private DialogManager _dialogManager;

    private void Awake()
    {
        _playerControl = new PlayerControl();
        _dialogManager = FindObjectOfType<DialogManager>();
    }

    private void OnEnable()
    {
        _playerControl.Enable();
    }

    private void OnDisable()
    {
        _playerControl.Disable();
    }

    public void TriggerDialogWithSmith()
    {
        _dialogManager.StartDialogWithSmith(dialog);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "Smith")
        {
            continueButtonPressed = false;
            onTrigger = true;

            TriggerDialogWithSmith();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.tag == "Player" && tag == "Smith")
        {
            onTrigger = false;

            FindObjectOfType<DialogManager>().EndDialogWithSmith();
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
            _dialogManager.DisplayNextSentence();
            continueButtonPressed = false;
        }
    }
}
