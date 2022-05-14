using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SignDialogManager : MonoBehaviour
{  
    public TextMeshProUGUI forestSignDialog;
    public Animator forestSignAnimator;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Awake()
    {
        forestSignDialog = GameObject.Find("ForestSignText").GetComponent<TextMeshProUGUI>();
        forestSignAnimator = GameObject.Find("ForestSignDialogBox").GetComponent<Animator>();
    }

    public void StartDialogWithSign(Dialog dialog)
    {
        forestSignAnimator.SetBool("SignIsOpen", true);

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
        foreach (var letter in sentence.ToCharArray())
        {
            forestSignDialog.text += letter;
            yield return new WaitForSecondsRealtime(0.008f);
        }
    }

    public void EndDialogWithSign()
    {
        forestSignAnimator.SetBool("SignIsOpen", false);
        forestSignDialog.text = "";
    }
}
