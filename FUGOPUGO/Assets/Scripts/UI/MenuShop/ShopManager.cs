using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopManager : MonoBehaviour
{

    [SerializeField] GameObject[] cubeSkins;
    private int currentSkinIndex;
    public SkinBluePrint[] skins;
    public Button buybtn;
    [SerializeField] private GameObject Marscoin;
    [SerializeField] private string namePlayer;
    void Start()
    {
        Marscoin = GameObject.Find("Marscoin");
        UpdateUI();
    }

    public void LoadPlayerStat()
    {
        currentSkinIndex = SaveGame.getIndexSkin();
        namePlayer = SaveGame.NamePlayer();
        foreach (GameObject cube in cubeSkins)
        {
            cube.SetActive(false);
        }
  
        cubeSkins[currentSkinIndex].SetActive(true);
        SaveGame.setSkinSelected(currentSkinIndex);
    }
    private void Update()
    {
    }
    // Next ->
    public void ChangeNext()
    {

        cubeSkins[currentSkinIndex].SetActive(false);
        currentSkinIndex ++;
        if (currentSkinIndex == cubeSkins.Length)
            currentSkinIndex = 0;
        
        cubeSkins[currentSkinIndex].SetActive(true);
        UpdateUI();
        SkinBluePrint c =  skins[currentSkinIndex];
        Debug.Log(currentSkinIndex);
        if (!SaveGame.IsUnlocked(currentSkinIndex,namePlayer))
            return;
            SaveGame.setSkinSelected(currentSkinIndex);
       
    }
    // Previous <-
    public void ChangePrevious()
    {
        cubeSkins[currentSkinIndex].SetActive(false);
        currentSkinIndex--;
        if (currentSkinIndex == -1)
            currentSkinIndex = cubeSkins.Length - 1;
        
        cubeSkins[currentSkinIndex].SetActive(true);
        UpdateUI();
        SkinBluePrint c = skins[currentSkinIndex];
        Debug.Log(currentSkinIndex);
        if (!SaveGame.IsUnlocked(currentSkinIndex, namePlayer))
            return;
        SaveGame.setSkinSelected(currentSkinIndex);
    }

    private void UpdateUI()
    {
        SkinBluePrint c = skins[currentSkinIndex];
        if (SaveGame.IsUnlocked(currentSkinIndex, namePlayer))
        {
            buybtn.gameObject.SetActive(false);
            Marscoin.SetActive(false);
        }
        else
        {
            buybtn.gameObject.SetActive(true);
            Marscoin.SetActive(true);
            buybtn.GetComponentInChildren<Text>().text = "Buy - " + SaveGame.GetCoins("Marscoin") + " / " + c.price;
            if (SaveGame.GetCoins("Marscoin") >= c.price)  
                buybtn.interactable = true;
            else
                buybtn.interactable = false;
        }
    }

  
    public void unlockSkin()
    {
        SkinBluePrint c = skins[currentSkinIndex];
        SaveGame.setSkinSelected(currentSkinIndex);
        SaveGame.UnlockSkin(currentSkinIndex,namePlayer);
        SaveGame.UpdateCoinAfterBuy("Marscoin", c.price);
        UpdateUI();
    }

    public void backResetUI()
    {
        buybtn.gameObject.SetActive(false);
        Marscoin.SetActive(false);
    }
}
