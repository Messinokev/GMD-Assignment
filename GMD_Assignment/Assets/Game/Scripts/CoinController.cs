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
    void Update()
    {
        LoadCoinCount();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            coinCount++;
            PlayerPrefs.SetInt("Coins", coinCount);
            Destroy(gameObject);
            SetCoinsText();
        }
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
