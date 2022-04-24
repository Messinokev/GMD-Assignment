using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmithTrigger : MonoBehaviour
{
    public Dialog firstQuest;
    public Dialog duringQuests;
    public Dialog firstQuestDone;
    public Dialog secondQuest;
    public Dialog secondQuestDone;

    private int _questProgress;

    public PlayerControl _playerControl;
    private bool continueButtonPressed = false;
    private bool onTrigger = false;

    public bool logsPickedUp = false;

    private DialogManager _dialogManager;

    private void Awake()
    {
        _playerControl = new PlayerControl();
        _dialogManager = FindObjectOfType<DialogManager>();

        _questProgress = PlayerPrefs.GetInt("Quest");

        if (_questProgress > 2)
        {
            GameObject.Find("furnaceOff").GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GameObject.Find("furnaceOff").GetComponent<SpriteRenderer>().enabled = true;
        }
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
        if (_questProgress == 0)
        {
            _dialogManager.StartDialogWithSmith(firstQuest);
        }
        if (_questProgress == 1)
        {
            _dialogManager.StartDialogWithSmith(duringQuests);
        }
        if (_questProgress == 2)
        {
            _dialogManager.StartDialogWithSmith(firstQuestDone);
        }
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

        if (_playerControl.Player.Shoping.triggered && FindObjectOfType<DialogManager>().smithDialogText.text.Contains("Press"))
        {
            if (_questProgress == 0)
            {
                GameObject.Find("EmptyFrame").GetComponent<RectTransform>().sizeDelta = new Vector2(0, 0);
            }

            if (_questProgress == 2)
            {
                GameObject.Find("furnaceOff").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("EmptyFrame").GetComponent<RectTransform>().sizeDelta = new Vector2(65, 65);
            }
            PlayerPrefs.SetInt("Quest", _questProgress + 1);
            _questProgress = PlayerPrefs.GetInt("Quest");
        }

        //ignite the furnace
        if (_questProgress == 1 && PlayerPrefs.GetInt("PickedLogs") == 1)
        {
            PlayerPrefs.SetInt("Quest", _questProgress + 1);
            _questProgress = PlayerPrefs.GetInt("Quest");
        }
    }
}
