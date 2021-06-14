using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public static class SaveData
{
    public static PlayerContainer playerContainer = new PlayerContainer();
    public static PlayerData user = new PlayerData();
    
    public static PlayerData FindPlayer(string path, string userToCheck)
    {
        PlayerData c = new PlayerData();
        playerContainer = LoadPlayers(path);
        if (playerContainer != null ) 
        {
            foreach (PlayerData data in playerContainer.player)
            {
                if (data.namePlayer == userToCheck)
                    return user = data;
            }
        }
        return c;
    }

    public static void Save(string path, PlayerContainer playerContainer)
    {
        SavePlayers(path, playerContainer);
       //ClearPlayerList();
    }

    public static void AddPlayerData(PlayerData data)
    {
        playerContainer.player.Add(data);
      
    }

    public static void ClearPlayerList()
    {
        playerContainer.player.Clear();
    }

    private static PlayerContainer LoadPlayers(string path)
    {
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<PlayerContainer>(json);
    }

    private static void SavePlayers(string path,PlayerContainer playerContainer)
    {
        string json = JsonUtility.ToJson(playerContainer,true);
        File.WriteAllText(path, json);
        Debug.Log("Salvato");
    }


}
