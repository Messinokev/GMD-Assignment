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

    public DataToSave(HealthBar health, PlayerController coin, HealthPotion potion, Respawn respawn)
    {
        this.health = health.currentHealth;
        coinCount = coin.coinCount;
        potionCount = potion.potionCount;

        playerPosition = new float[3];
        playerPosition[0] = respawn.transform.position.x;
        playerPosition[1] = respawn.transform.position.y;
        playerPosition[2] = respawn.transform.position.z;
    }

}
