using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveStatsWithLogs(HealthBar health, int coin, HealthPotion potion, Respawn respawn, PickableLogsScript logs,  float[] camera)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveData.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataToSave data = new DataToSave(health, coin, potion, respawn, logs, camera);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static void SaveStatsWithEgg(HealthBar health, int coin, HealthPotion potion, Respawn respawn, float[] camera, PickableEggScript egg)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/saveData.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataToSave data = new DataToSave(health, coin, potion, respawn, camera, egg);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataToSave LoadStats()
    {
        string path = Application.persistentDataPath + "/saveData.save";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            DataToSave data =  formatter.Deserialize(stream) as DataToSave;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
