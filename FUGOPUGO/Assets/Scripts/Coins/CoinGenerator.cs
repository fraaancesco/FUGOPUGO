using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{   
    [SerializeField] private GameObject ObjectPooler;
    [SerializeField] private string typeCoin;
    [SerializeField] private int totalSpawnCoin;
    [SerializeField] private int numSpawnCoin;
    private void Start()
    {
        typeCoin = CoinManager.Instance.coins[0].tag;
        ObjectPooler = GameObject.Find("ObjectPooler");
        totalSpawnCoin = ObjectPooler.GetComponent<ObjectPooler>().poolDictionary.Count;
        numSpawnCoin = 0;
    }

    public void SpawnCoins(int typeSpawn, Transform startPosition,  int distanceBetweenCoins, int numCoinForRow)
    {
        switch(typeSpawn)
        {
            case 1:
                SpawnRowCoinHorizontal(startPosition, distanceBetweenCoins, numCoinForRow);
                break;

            case 2:
                SpawnRowCoinVertical(startPosition, distanceBetweenCoins, numCoinForRow);
                break;

            case 3:
                SpawnRowCoinDiagonallyLeft(startPosition, distanceBetweenCoins, numCoinForRow);
                break;
            case 4:
                SpawnRowCoinDiagonallyRight(startPosition, distanceBetweenCoins, numCoinForRow);
                break;

            default:
                break;
        }
    }

    // Spawn coins horizontal
    private void SpawnRowCoinHorizontal(Transform startPosition, float distanceBetweenCoins, int numCoinForRow)
    { 
        numSpawnCoin = 0;

        if (numSpawnCoin < totalSpawnCoin)
        {
            while (numSpawnCoin < numCoinForRow)
            {
                GameObject coin = ObjectPooler.GetComponent<ObjectPooler>().getPooledObject(typeCoin);
                Vector3 position = new Vector3(startPosition.position.x, startPosition.position.y, startPosition.position.z + distanceBetweenCoins);
                startPosition.position = position;
                coin.transform.Spawn(startPosition);
                numSpawnCoin++;
                totalSpawnCoin++;
            }
        }
        else
        {
            Debug.LogWarning("I can't spawn the marscoin");
        }
    }

    // Spawn coins vertical
    private void SpawnRowCoinVertical(Transform startPosition, float distanceBetweenCoins, int numCoinForRow)
    {
        numSpawnCoin = 0;

        if (numSpawnCoin < totalSpawnCoin)
        {
            while (numSpawnCoin < numCoinForRow)
            {
                GameObject coin = ObjectPooler.GetComponent<ObjectPooler>().getPooledObject(typeCoin);
                Vector3 position = new Vector3(startPosition.position.x + distanceBetweenCoins, startPosition.position.y, startPosition.position.z);
                startPosition.position = position;
                coin.transform.Spawn(startPosition);
                numSpawnCoin++;
                totalSpawnCoin++;
            }
        }
        else
        {
            Debug.LogWarning("I can't spawn the marscoin");
        }
    }

    // Spawn coins diagonally left
    private void SpawnRowCoinDiagonallyLeft(Transform startPosition, float distanceBetweenCoins, int numCoinForRow)
    {
        numSpawnCoin = 0;

        if (numSpawnCoin < totalSpawnCoin)
        {
            while (numSpawnCoin < numCoinForRow)
            {
                GameObject coin = ObjectPooler.GetComponent<ObjectPooler>().getPooledObject(typeCoin);
                Vector3 position = new Vector3(startPosition.position.x - distanceBetweenCoins, startPosition.position.y, startPosition.position.z + distanceBetweenCoins);
                startPosition.position = position;
                coin.transform.Spawn(startPosition);
                numSpawnCoin++;
                totalSpawnCoin++;
            }
        }
        else
        {
            Debug.LogWarning("I can't spawn the marscoin");
        }
    }

    // Spawn coins diagonally right
    private void SpawnRowCoinDiagonallyRight(Transform startPosition, float distanceBetweenCoins, int numCoinForRow)
    {
        numSpawnCoin = 0;

        if (numSpawnCoin < totalSpawnCoin)
        {
            while (numSpawnCoin < numCoinForRow)
            {
                GameObject coin = ObjectPooler.GetComponent<ObjectPooler>().getPooledObject(typeCoin);
                Vector3 position = new Vector3(startPosition.position.x + distanceBetweenCoins, startPosition.position.y, startPosition.position.z + distanceBetweenCoins);
                startPosition.position = position;
                coin.transform.Spawn(startPosition);
                numSpawnCoin++;
                totalSpawnCoin++;
            }
        }
        else
        {
            Debug.LogWarning("I can't spawn the marscoin");
        }
    }

}