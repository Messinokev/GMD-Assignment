using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSignTrigger : MonoBehaviour
{
    public Dialog dialog;
    public Dialog finsihedMinedialog;
    private SignDialogManager _dialogManager;
    private int _questProgress;

    void Awake()
    {
        _dialogManager = FindObjectOfType<SignDialogManager>();
        _questProgress = PlayerPrefs.GetInt("Quest");

        if (_questProgress > 3 && _questProgress < 6)
        {
            GameObject.Find("mineSign").GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GameObject.Find("mineSign").GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "MineSign")
        {
            if (_questProgress < 4)
            {
                _dialogManager.StartDialogWithSign(dialog);
            }
            else
            {
                _dialogManager.StartDialogWithSign(finsihedMinedialog);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "MineSign")
        {
            _dialogManager.EndDialogWithSign();
        }
    }
}
