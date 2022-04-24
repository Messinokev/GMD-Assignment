using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{

    public static void SaveStats(HealthBar health, PlayerController coin, HealthPotion potion, Respawn respawn, PickableLogsScript logs)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/stats.save";
        FileStream stream = new FileStream(path, FileMode.Create);

        DataToSave data = new DataToSave(health, coin, potion, respawn, logs);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static DataToSave LoadStats()
    {
        string path = Application.persistentDataPath + "/stats.save";
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
