using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static int coinCount = 0;
    private TextMeshProUGUI coinsText;

    void Start()
    {
        coinsText = GameObject.Find("CoinText").GetComponent<TextMeshProUGUI>();

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
            Destroy(gameObject);
        }
    }

    private void SetCoinsText()
    {
        coinsText.text = coinCount.ToString();
    }
}
