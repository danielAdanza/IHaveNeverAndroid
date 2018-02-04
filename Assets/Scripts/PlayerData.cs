using UnityEngine;
using System.Collections;
//added for serialization
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerData : MonoBehaviour
{

    public static PlayerData playerData;
    public int languaje;

    void Awake()
    {

        if (playerData == null)
        {
            DontDestroyOnLoad(gameObject);
            playerData = this;
        }
        else
        {
            Destroy(gameObject);
        }
        this.Load();
    }

    //funciona con todo excepto con web
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerdata.dat");

        Player player = new Player(playerData.languaje);
        bf.Serialize(file, player);
        file.Close();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerdata.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerdata.dat", FileMode.Open);
            Player player = (Player)bf.Deserialize(file);
            file.Close();

            playerData.languaje = player.languaje;
        }
    }

}

[Serializable]
class Player
{
    public Player(int languaje)
    {
        this.languaje = languaje;
    }

    public int languaje;

}