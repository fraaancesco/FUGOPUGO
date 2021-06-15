using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
public static class SaveGame
{

    private static string targetFilePathSetting = GameManager.Instance.gameObject.GetComponent<GameManager>().filePathSetting;

    public static string NamePlayer()
    {
        return GameManager.playerinfo.namePlayer;
    }

    public static void SaveCoins(string typeCoin, int coins)
    {     
        foreach (PlayerData data in SaveData.playerContainer.player) 
        {
            if (data.namePlayer == GameManager.playerinfo.namePlayer)
                data.wallet += coins;
        }
        SaveData.Save(targetFilePathSetting, SaveData.playerContainer);
    }
    public static void UpdateCoinAfterBuy(string typeCoin, int coins)
    {
        foreach (PlayerData data in SaveData.playerContainer.player)
        {
            if (data.namePlayer == GameManager.playerinfo.namePlayer)
                data.wallet -= coins;
        }
        SaveData.Save(targetFilePathSetting, SaveData.playerContainer);
    }
    public static int GetCoins(string typeCoin)
    {
        return GameManager.playerinfo.wallet;
    }

    public static int getIndexSkin()
    {
        foreach (PlayerData data in SaveData.playerContainer.player)
        {
            if (data.namePlayer == GameManager.playerinfo.namePlayer)
                return GameManager.playerinfo.indexSkin;
        }
        return 0;
    }

    public static void setSkinSelected(int skinSelected)
    {
        foreach (PlayerData data in SaveData.playerContainer.player)
        {
            if(data.namePlayer == GameManager.playerinfo.namePlayer)
                data.indexSkin = skinSelected;
        }
        SaveData.Save(targetFilePathSetting, SaveData.playerContainer);
    }
    public static void UnlockSkin(int skinToUnlock , string nameToCheck)
    {
        foreach (PlayerData data in SaveData.playerContainer.player)
        {
            if (data.namePlayer == nameToCheck && data.skinUnlocked[skinToUnlock] == false)
                data.skinUnlocked[skinToUnlock] = true;
        }
        SaveData.Save(targetFilePathSetting, SaveData.playerContainer);
    }

    public static bool IsUnlocked(int indexToCheck, string nameToCheck)
    {
        foreach (PlayerData data in SaveData.playerContainer.player)
        {
          if(data.namePlayer == nameToCheck && data.skinUnlocked[indexToCheck] == true) 
                    return data.skinUnlocked[indexToCheck];
        }
        return false;
    }

    public static void SaveLevel(int LevelPassed)
    {
        foreach (PlayerData data in SaveData.playerContainer.player)
        {
            if (data.namePlayer == GameManager.playerinfo.namePlayer)
                data.levelPassed = LevelPassed ; 
        }
        SaveData.Save(targetFilePathSetting, SaveData.playerContainer);
    }
    public static int GetLevelPassed()
    {
        return GameManager.playerinfo.levelPassed;
    }

    public static void SaveScoreLevel(double score)
    {
        int indexlevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(score);
        foreach (PlayerData data in SaveData.playerContainer.player)
        {
            if (data.namePlayer == GameManager.playerinfo.namePlayer)
            {
                Debug.Log("ciao");
                if (data.score[indexlevel - 2] < score) 
                {
                    Debug.Log("sono dentro");
                    data.score[indexlevel - 2] = score;
                }
                        
            }
            Debug.Log("score ::: " + data.score[indexlevel-2]);
        }
        
        SaveData.Save(targetFilePathSetting, SaveData.playerContainer);
    }
    public static double GetScoreLevel(int level)
    {
        return GameManager.playerinfo.score[level];
    }
}
   
