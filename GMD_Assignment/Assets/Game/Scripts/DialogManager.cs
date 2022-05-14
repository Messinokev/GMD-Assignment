using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI merchantNPCNameText;
    public TextMeshProUGUI merchantDialogText;
    public TextMeshProUGUI merchantContinueText;
    public TextMeshProUGUI smithNPCNameText;
    public TextMeshProUGUI smithDialogText;
    public TextMeshProUGUI smithContinueText;
    public Animator merchantAnimator;
    public Animator smithAnimator;
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogWithMerchant(Dialog dialog)
    {
        merchantAnimator.SetBool("IsOpen", true);

        merchantNPCNameText.text = dialog.name;
        merchantContinueText.text = "Continue>>";

        sentences.Clear();

        foreach (string sentence in dialog.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void StartDialogWithSmith(Dialog dialog)
    {
        smithAnimator.SetBool("SmithIsOpen", true);

        smithNPCNameText.text = dialog.name;
        smithContinueText.text = "Continue>>";

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
            merchantContinueText.text = "";
            smithContinueText.text = "";
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public IEnumerator TypeSentence(string sentence)
    {
        merchantDialogText.text = "";
        smithDialogText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            merchantDialogText.text += letter;
            smithDialogText.text += letter;
            yield return new WaitForSecondsRealtime(0.008f);
        }
    }

    public void EndDialogWithMerchant()
    {
        merchantAnimator.SetBool("IsOpen", false);
        merchantNPCNameText.text = "";
        merchantDialogText.text = "";
        merchantContinueText.text = "";
    }

    public void EndDialogWithSmith()
    {
        smithAnimator.SetBool("SmithIsOpen", false);
        smithNPCNameText.text = "";
        smithDialogText.text = "";
        smithContinueText.text = "";
    }
}
