using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataToSave
{
    public int health;
    public int coinCount;
    public int potionCount;
    public float[] playerPosition;
    public bool pickedLogs;

    public DataToSave(HealthBar health, int coin, HealthPotion potion, Respawn respawn, PickableLogsScript logs)
    {
        this.health = health.currentHealth;
        coinCount = coin;
        potionCount = potion.potionCount;
        pickedLogs = logs.pickedUp;

        playerPosition = new float[3];
        playerPosition[0] = respawn.transform.position.x;
        playerPosition[1] = respawn.transform.position.y;
        playerPosition[2] = respawn.transform.position.z;
    }

}
