using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToForest : MonoBehaviour
{
    public Dialog dialog;
    public Dialog finsihedForestdialog;
    private SignDialogManager _dialogManager;
    private int _questProgress;

    void Awake()
    {
        _dialogManager = FindObjectOfType<SignDialogManager>();
        _questProgress = PlayerPrefs.GetInt("Quest");

        if (_questProgress > 0 && _questProgress < 3)
        {
            GameObject.Find("ForestSign").GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GameObject.Find("ForestSign").GetComponent<BoxCollider2D>().enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "ForestSign")
        {
            if (_questProgress == 0)
            {
                _dialogManager.StartDialogWithSign(dialog);
            }
            else
            {
                _dialogManager.StartDialogWithSign(finsihedForestdialog);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "ForestSign")
        {
            _dialogManager.EndDialogWithSign();
        }
    }
}
