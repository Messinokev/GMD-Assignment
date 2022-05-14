using TMPro;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private GameObject _noPotion;
    private GameObject _hasPotion;
    public HealthBar healthBar;
    public  int potionCount;
    public TextMeshProUGUI potionCountText;
    public PlayerControl _playerControl;

    private void Awake()
    {
        _playerControl = new PlayerControl();
    }

    void Start()
    {
        _noPotion = transform.GetChild(0).gameObject;
        _hasPotion = transform.GetChild(1).gameObject;

        SetPotionCountText();
    }

    private void OnEnable()
    {
        _playerControl.Enable();
    }

    private void OnDisable()
    {
        _playerControl.Disable();
    }

    void Update()
    {
        SetPotionCountText();

        bool potionButtonPressed = _playerControl.Player.UsePotion.triggered;

        if (potionButtonPressed)
        {
            useHealthPotion();
        }

        if (potionCount > 0)
        {
            _noPotion.SetActive(false);
            _hasPotion.SetActive(true);
        }
        else
        {
            _noPotion.SetActive(true);
            _hasPotion.SetActive(false);
        }
    }

    void useHealthPotion()
    {
        if (potionCount > 0 && healthBar.currentHealth < healthBar.maxHealth)
        {
            healthBar.AddHealth(20);
            potionCount--;
        }
    }

    public void SetPotionCountText()
    {
        potionCountText.text = potionCount.ToString();
    }

    public bool HasSpaceForPotion()
    {
        if (potionCount < 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BuyPotion()
    {
        potionCount++;
        SetPotionCountText();
    }
}
