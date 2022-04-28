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

    private SpriteRenderer furnaceOffSpriteRenderer;
    private RectTransform emptyFrameRectTrans;

    private PlayerController playerController;

    private void Awake()
    {
        _playerControl = new PlayerControl();
        _dialogManager = FindObjectOfType<DialogManager>();

        _questProgress = PlayerPrefs.GetInt("Quest");

        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        furnaceOffSpriteRenderer = GameObject.Find("furnaceOff").GetComponent<SpriteRenderer>();
        emptyFrameRectTrans = GameObject.Find("EmptyFrame").GetComponent<RectTransform>();

        if (_questProgress > 2)
        {
            furnaceOffSpriteRenderer.enabled = false;
        }
        else
        {
            furnaceOffSpriteRenderer.enabled = true;
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

            _dialogManager.EndDialogWithSmith();
        }
    }

    private void Update()
    {
        //Dialog with the Smith
        if (_playerControl.Player.ContinueDialog.triggered)
        {
            continueButtonPressed = true;
        }
        //Dialog with the Smith
        if (onTrigger && continueButtonPressed)
        {
            _dialogManager.DisplayNextSentence();
            continueButtonPressed = false;
        }

        //Main Story Line
        if (_playerControl.Player.Shoping.triggered && _dialogManager.smithDialogText.text.Contains("(UpArrow)"))
        {
            if (_questProgress == 0)
            {
                emptyFrameRectTrans.sizeDelta = new Vector2(0f, 0f);
            }

            if (_questProgress == 2)
            {
                furnaceOffSpriteRenderer.enabled = false;
                emptyFrameRectTrans.sizeDelta = new Vector2(125f, 125f);
                playerController.ChangeAnimation();
            }
            PlayerPrefs.SetInt("Quest", _questProgress + 1);
            _questProgress = PlayerPrefs.GetInt("Quest");
        }

        //Smith sees that you picked up the logs
        if (_questProgress == 1 && PlayerPrefs.GetInt("PickedLogs") == 1)
        {
            PlayerPrefs.SetInt("Quest", _questProgress + 1);
            _questProgress = PlayerPrefs.GetInt("Quest");
        }
    }
}
