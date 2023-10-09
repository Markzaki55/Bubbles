using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveManger
{
    public static int highScore;
    private static readonly string SAVE_FILE_NAME = "playerInfo.dat";

    public static void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + SAVE_FILE_NAME))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + SAVE_FILE_NAME, FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);

            highScore = data.highScore;
            file.Close();
        }
        else
        {
                 highScore = 0;

            Save();
        }
    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + SAVE_FILE_NAME);
        PlayerData data = new PlayerData();

        data.highScore = highScore;

        bf.Serialize(file, data);
        file.Close();
    }
}

[System.Serializable]
class PlayerData
{
    public int highScore;
}