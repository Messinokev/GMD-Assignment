using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static int coinCount;
    private TextMeshProUGUI coinsText;

    void Start()
    {
        coinsText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();

        LoadCoinCount();

        SetCoinsText();
    }

    // Update is called once per frame
    void Update()
    {
        //Set coin text
        SetCoinsText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            coinCount++;
            PlayerPrefs.SetInt("Coins", coinCount);
            Destroy(gameObject);
        }
    }

    public void LoadCoinCount()
    {
        //coinCount = FindObjectOfType<PlayerController>().coinCount;
        coinCount = PlayerPrefs.GetInt("Coins");
    }

    private void SetCoinsText()
    {
        coinsText.text = coinCount.ToString();
    }

    public bool HasEnoughCoins(int price)
    {
        if (coinCount >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void SpendCoin(int price)
    {
        coinCount -= price;
        PlayerPrefs.SetInt("Coins", coinCount);
        SetCoinsText();
    }

}
