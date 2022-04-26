using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignDialogManager : MonoBehaviour
{
    
    public TextMeshProUGUI forestSignDialog;
    public TextMeshProUGUI mineSignDialog;
    

    public Animator forestSignAnimator;
    public Animator mineSignAnimator;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogWithForestSign(Dialog dialog)
    {
        forestSignAnimator.SetBool("ForestIsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartDialogWithMineSign(Dialog dialog)
    {
        mineSignAnimator.SetBool("MineIsOpen", true);

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public IEnumerator TypeSentence(string sentence)
    {
        forestSignDialog.text = "";
        //mineSignDialog.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            forestSignDialog.text += letter;
            //mineSignDialog.text += letter;
            yield return new WaitForSecondsRealtime(0.008f);
        }
    }

    public void EndDialogWithForestSign()
    {
        forestSignAnimator.SetBool("ForestIsOpen", false);
        forestSignDialog.text = "";
    }

    public void EndDialogWithMineSign()
    {
        mineSignAnimator.SetBool("MineIsOpen", false);
        mineSignDialog.text = "";
    }
}
