using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSignTrigger : MonoBehaviour
{
    public Dialog dialog;
    private SignDialogManager _dialogManager;

    void Awake()
    {
        _dialogManager = FindObjectOfType<SignDialogManager>();

        if (PlayerPrefs.GetInt("Quest") > 3)
        {
            GameObject.Find("mineSign").GetComponent<BoxCollider2D>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "MineSign")
        {
            _dialogManager.StartDialogWithSign(dialog);
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
