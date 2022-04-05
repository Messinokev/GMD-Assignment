using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI NPCnameText;
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI continueText;

    public Animator animator;

    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();

    }

    public void StartDialog(Dialog dialog)
    {
        animator.SetBool("IsOpen", true);

        NPCnameText.text = dialog.name;
        continueText.text = "Continue>>";

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
        if (sentences.Count == 1)
        {
            continueText.text = "";
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSecondsRealtime(0.008f);
        }
    }

    public void EndDialog()
    {
        animator.SetBool("IsOpen", false);
        NPCnameText.text = "";
        dialogText.text = "";
        continueText.text = "";
    }



}
