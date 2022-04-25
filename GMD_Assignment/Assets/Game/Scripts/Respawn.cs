using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    [SerializeField] private Transform player;

    public PlayerControl _playerControl;

    private HealthBar health;
    private PlayerController coin;
    private HealthPotion potion;
    private PickableLogsScript logs;
    private CameraController cameraPosition;

    private void Start()
    {
        LoadData();
    }

    private void Awake()
    {
        _playerControl = new PlayerControl();
        health = FindObjectOfType<HealthBar>();
        //coin = FindObjectOfType<PlayerController>();
        potion = FindObjectOfType<HealthPotion>();
        logs = FindObjectOfType<PickableLogsScript>();
        cameraPosition = FindObjectOfType<CameraController>();
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
        int coin = PlayerPrefs.GetInt("Coins");
        Vector3 camPos = GameObject.Find("Main Camera").transform.position;
        float[] camPosition = new float[3];
        camPosition[0] = camPos.x;
        camPosition[1] = camPos.y;
        camPosition[2] = camPos.z;


        SaveSystem.SaveStats(health, coin, potion, this, logs, camPosition);
    }

    public void LoadData()
    {
        DataToSave data = SaveSystem.LoadStats();

        health.currentHealth = data.health;
        health.SetHealth(data.health);
        PlayerPrefs.SetInt("Coins", data.coinCount);
        FindObjectOfType<CoinController>().LoadCoinCount();
        potion.potionCount = data.potionCount;
        logs.pickedUp = data.pickedLogs;
        logs.LogsLoadedBack();

        Vector3 playerPostion;
        playerPostion.x = data.playerPosition[0];
        playerPostion.y = data.playerPosition[1];
        playerPostion.z = data.playerPosition[2];
        GameObject.Find("Player").transform.position = playerPostion;

        Vector3 cameraPostion;
        cameraPostion.x = data.cameraPosition[0];
        cameraPostion.y = data.cameraPosition[1];
        cameraPostion.z = data.cameraPosition[2];
        GameObject.Find("Main Camera").transform.position = cameraPostion;
    }
}
