using System.Collections.Generic;

public class CoinManager : Singleton<CoinManager>
{
    [System.Serializable]
    public class Coin
    {
        public string tag;
        public int value;
    }

    public List<Coin> coins;
    
    private void Awake()
    {
        coins[0].value = SaveGame.GetCoins("Marscoin");
    }

    protected override void OnAwake()
    {
        _persistent = true;
    }

    public int GetCoinsOfLevel()
    {
        return coins[0].value;
    }

    public void AddCoins(int coinsToAdd)
    {
        coins[0].value += coinsToAdd;
    }

    public void SaveCoins()
    {    
        SaveGame.SaveCoins("Marscoin", coins[0].value);
    }

    public void ResetCoins()
    {
        coins[0].value = 0;
    }


}
