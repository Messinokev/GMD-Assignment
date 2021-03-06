using UnityEngine;

public class Respawn : MonoBehaviour
{
    private Vector3 respawnPoint;
    [SerializeField] private Transform player;
    public PlayerControl _playerControl;
    private HealthBar health;
    private HealthPotion potion;
    private PickableLogsScript logs;
    private bool isLogs = false;
    private PickableEggScript egg;
    private bool isEgg = false;

    private void Start()
    {
        checkForPickables();

        if (isLogs)
        {
            LoadDataWithLogs();
        }
        if (isEgg)
        {
            LoadDataWithEgg();
        }

        if (PlayerPrefs.GetInt("AtMine") == 1)
        {
            GameObject.Find("Player").transform.position = new Vector3(19.5f, -4.5f, 0f);
            GameObject.Find("Main Camera").transform.position = new Vector3(19.3f, -1.5f, -10f);
            PlayerPrefs.SetInt("AtMine", 0);
        }

        if (PlayerPrefs.GetInt("PickedEgg") == 1)
        {
            if (PlayerPrefs.GetInt("Quest") == 4 || PlayerPrefs.GetInt("Quest") == 5)
            {
                GameObject.Find("NoEgg").GetComponent<RectTransform>().sizeDelta = new Vector2(0f, 0f);
            }
        }
    }

    private void Awake()
    {
        _playerControl = new PlayerControl();

        health = FindObjectOfType<HealthBar>();
        potion = FindObjectOfType<HealthPotion>();
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
    }

    public void checkForPickables()
    {
        if (FindObjectOfType<PickableLogsScript>())
        {
            logs = FindObjectOfType<PickableLogsScript>();
            isLogs = true;
        }
        else
        {
            isLogs = false;
        }
        if (FindObjectOfType<PickableEggScript>())
        {
            egg = FindObjectOfType<PickableEggScript>();
            isEgg = true;
        }
        else
        {
            isEgg = false;
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
        if (collision.tag == "Checkpoint1" || collision.tag == "Checkpoint2" || collision.tag == "Checkpoint3" || collision.tag == "Checkpoint4")
        {
            respawnPoint = transform.position;
            checkForPickables();
            SaveDataWithLogs();
        }
        if (collision.tag == "Checkpoint6" || collision.tag == "Checkpoint7" || collision.tag == "Checkpoint8" || collision.tag == "Checkpoint9")
        {
            respawnPoint = transform.position;
            checkForPickables();
            SaveDataWithEgg();
        }
        if (collision.tag == "Checkpoint")
        {
            SaveDataWithLogs();
        }
    }

    /*---I have tried to separete the methods below to a separate SaveAndLoad class,
     but I have always got a object reference to null exception for some reason...---*/

    public void SaveDataWithLogs()
    {
        int coin = PlayerPrefs.GetInt("Coins");
        Vector3 camPos = GameObject.Find("Main Camera").transform.position;
        float[] camPosition = new float[3];
        camPosition[0] = camPos.x;
        camPosition[1] = camPos.y;
        camPosition[2] = camPos.z;

        SaveSystem.SaveStatsWithLogs(health, coin, potion, this, logs, camPosition);
    }

    public void SaveDataWithEgg()
    {
        int coin = PlayerPrefs.GetInt("Coins");
        Vector3 camPos = GameObject.Find("Main Camera").transform.position;
        float[] camPosition = new float[3];
        camPosition[0] = camPos.x;
        camPosition[1] = camPos.y;
        camPosition[2] = camPos.z;

        SaveSystem.SaveStatsWithEgg(health, coin, potion, this, camPosition, egg);
    }

    private DataToSave GeneralLoad()
    {
        DataToSave data = SaveSystem.LoadStats();

        health.currentHealth = data.health;
        health.SetHealth(data.health);
        PlayerPrefs.SetInt("Coins", data.coinCount);
        FindObjectOfType<CoinController>().LoadCoinCount();
        potion.potionCount = data.potionCount;

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

        return data;
    }

    public void LoadDataWithLogs()
    {
        DataToSave data = GeneralLoad();
        logs.pickedUp = data.pickedLogs;
        logs.LogsLoadedBack();
    }

    public void LoadDataWithEgg()
    {
        DataToSave data = GeneralLoad();
        egg.pickedUp = data.pickedEgg;
        egg.EggLoadedBack();
    }
}
