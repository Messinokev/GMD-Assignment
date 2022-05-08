using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public Animator animator;

    public static int coinCount;
    private TextMeshProUGUI coinsText;
    // Start is called before the first frame update
    void Start()
    {
        coinsText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();

        LoadCoinCount();

        SetCoinsText();
    }

    // Update is called once per frame
    void Update()
    {
        LoadCoinCount();
    }

    public void SmashBox()
    {
        animator.Play($"Box_smash");
        StartCoroutine(WaitForSmashAnimation());
    }
    
    IEnumerator WaitForSmashAnimation()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorClipInfo(0).Length);
        coinCount+=3;
        PlayerPrefs.SetInt("Coins", coinCount);
        SetCoinsText();
        Destroy(gameObject);
    }

    public void LoadCoinCount()
    {
        coinCount = PlayerPrefs.GetInt("Coins");
        SetCoinsText();
    }

    private void SetCoinsText()
    {
        coinsText.text = coinCount.ToString();
    }
}
