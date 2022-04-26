using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToForest : MonoBehaviour
{
    public Dialog dialog;
    private bool onTrigger = false;
    private SignDialogManager _dialogManager;

    void Awake()
    {
        _dialogManager = FindObjectOfType<SignDialogManager>();

        if (PlayerPrefs.GetInt("Quest") > 0)
        {
            GameObject.Find("ForestSign").GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    public void TriggerDialogWithForestSign()
    {
        _dialogManager.StartDialogWithForestSign(dialog);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "ForestSign")
        {

            //onTrigger = true;
            //Debug.Log("Enter");

            TriggerDialogWithForestSign();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "ForestSign")
        {
            //onTrigger = false;

            //Debug.Log("Exit");

            _dialogManager.EndDialogWithForestSign();
        }
    }
}
