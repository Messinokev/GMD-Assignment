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
    public float[] cameraPosition;

    public DataToSave(HealthBar health, int coin, HealthPotion potion, Respawn respawn, PickableLogsScript logs, float[] camera)
    {
        this.health = health.currentHealth;
        coinCount = coin;
        potionCount = potion.potionCount;
        pickedLogs = logs.pickedUp;

        playerPosition = new float[3];
        playerPosition[0] = respawn.transform.position.x;
        playerPosition[1] = respawn.transform.position.y;
        playerPosition[2] = respawn.transform.position.z;

        cameraPosition = new float[3];
        cameraPosition[0] = camera[0];
        cameraPosition[1] = camera[1];
        cameraPosition[2] = camera[2];
    }

}
