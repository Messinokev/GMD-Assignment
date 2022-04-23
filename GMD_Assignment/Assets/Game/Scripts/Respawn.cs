using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    [SerializeField] private Transform player;

    public PlayerControl _playerControl;

    private void Awake()
    {
        _playerControl = new PlayerControl();
    }

        private void FixedUpdate()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }
    }

    void LateUpdate()
    {
        if (player)
        {
            transform.position = player.transform.position;
        }

        if (_playerControl.Player.LoadSaving.triggered)
        {
            LoadData();
        }
    }

    private void OnEnable()
    {
        _playerControl.Enable();
    }

    private void OnDisable()
    {
        _playerControl.Disable();
    }

    public void SetPlayerToSpawn()
    {
        player.position = respawnPoint;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Checkpoint")
        {
            respawnPoint = transform.position;
            SaveData();
        }
    }

    public void SaveData()
    {
        HealthBar helth = FindObjectOfType<HealthBar>();
        PlayerController coin = FindObjectOfType<PlayerController>();
        HealthPotion potion = FindObjectOfType<HealthPotion>();

        SaveSystem.SaveStats(helth, coin, potion, this);
    }

    public void LoadData()
    {
        DataToSave data = SaveSystem.LoadStats();

        FindObjectOfType<HealthBar>().currentHealth = data.health;
        FindObjectOfType<HealthBar>().SetHealth(data.health);
        FindObjectOfType<PlayerController>().coinCount = data.coinCount;
        FindObjectOfType<CoinController>().LoadCoinCount();
        FindObjectOfType<HealthPotion>().potionCount = data.potionCount;

        Vector3 playerPostion;
        playerPostion.x = data.playerPosition[0];
        playerPostion.y = data.playerPosition[1];
        playerPostion.z = data.playerPosition[2];
        GameObject.Find("Player").transform.position = playerPostion;
    }
}
