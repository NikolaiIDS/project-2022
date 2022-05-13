using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(ThirdPersonScript tps)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/player.xd";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(tps);

        formatter.Serialize(stream, data);
        stream.Close();
        
    }
    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.xd";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            return data;
        }
        else
        {
            Debug.LogError("Fine not found in" + path);
            return null;
        }
    }
}
