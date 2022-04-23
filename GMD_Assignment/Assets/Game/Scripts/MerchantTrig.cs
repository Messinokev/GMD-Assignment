using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public PlayerControl _playerControl;
    private bool continueButtonPressed = false;
    private bool onTrigger = false;
    private bool canShop = false;

    [SerializeField] private int potionPrice = 5;
    private CoinController _coinController;
    private HealthPotion _healthPotion;
    private DialogManager _dialogManager;

    private void Awake()
    {
        _playerControl = new PlayerControl();
        _coinController = FindObjectOfType<CoinController>();
        _healthPotion = FindObjectOfType<HealthPotion>();
        _dialogManager = FindObjectOfType<DialogManager>();
    }

    private void OnEnable()
    {
        _playerControl.Enable();
    }

    private void OnDisable()
    {
        _playerControl.Disable();
    }

    public void TriggerDialogWithMerchant()
    {
        _dialogManager.StartDialogWithMerchant(dialog);
    }

    public void TriggerDialogWithSmith()
    {
        _dialogManager.StartDialogWithSmith(dialog);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "Merchant")
        {
            continueButtonPressed = false;
            onTrigger = true;
            canShop = true;

            TriggerDialogWithMerchant();
        }
        if (collision.tag == "Player" && tag == "Smith")
        {
            continueButtonPressed = false;
            onTrigger = true;

            TriggerDialogWithSmith();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && tag == "Merchant")
        {
            onTrigger = false;
            canShop = true;
            FindObjectOfType<DialogManager>().EndDialogWithMerchant();
        }
        if (collision.tag == "Player" && tag == "Smith")
        {
            onTrigger = false;
           
            FindObjectOfType<DialogManager>().EndDialogWithSmith();
        }
    }


    private void Update()
    {
        if (_playerControl.Player.ContinueDialog.triggered)
        {
            continueButtonPressed = true;
        }

        if (onTrigger && continueButtonPressed)
        {
            _dialogManager.DisplayNextSentence();
            continueButtonPressed = false;
        }

        if (canShop && _playerControl.Player.Shoping.triggered && FindObjectOfType<DialogManager>().merchantDialogText.text.Contains("Press"))
        {
            if (_coinController.HasEnoughCoins(potionPrice))
            {
                if (_healthPotion.HasSpaceForPotion())
                {
                    _coinController.SpendCoin(potionPrice);
                    _healthPotion.BuyPotion();
                }
                else
                {
                    StartCoroutine(_dialogManager.TypeSentence("You can't carry more then 5 potions, Anke!"));

                }
            }
            else
            {
                StartCoroutine(_dialogManager.TypeSentence("You don't have enough coins, Anke!"));
            }

        }
    }

}
