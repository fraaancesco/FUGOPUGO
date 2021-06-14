using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlatformSpawnCoin : MonoBehaviour
{
    [SerializeField] private CoinGenerator coin;
    [SerializeField] private List<GameObject> spawnPoints;
    private Transform SpawnTrans;


    private void Awake()
    {
         coin = GameObject.Find("SpawnCoins").GetComponent<CoinGenerator>();
         spawnPoints = new List<GameObject>();

        // Level 01
        if (SceneManager.GetActiveScene().buildIndex == 2) 
        { 

             spawnPoints.Add(GameObject.Find("PointSpawnCoin_1"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_2"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_3"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_4"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_5"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_6"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_7"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_8"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_9"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_10"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_11"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_12"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_13"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_14"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_15"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_16"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_17"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_18"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_19"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_20"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_21"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_22"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_23"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_24"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_25"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_26"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_27"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_28"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_29"));
             spawnPoints.Add(GameObject.Find("PointSpawnCoin_30"));
        }
    }
    private void Start()
    {
        // Level 01
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {

            SpawnForEachPointTheCoins(1, spawnPoints[0].transform, 1, 5);
            SpawnForEachPointTheCoins(1, spawnPoints[1].transform, 2, 4);
            SpawnForEachPointTheCoins(1, spawnPoints[2].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[3].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[4].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[5].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[6].transform, 3, 30);
            SpawnForEachPointTheCoins(1, spawnPoints[7].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[8].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[9].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[10].transform, 5, 5);
            SpawnForEachPointTheCoins(1, spawnPoints[11].transform, 2, 5);
            SpawnForEachPointTheCoins(1, spawnPoints[12].transform, 2, 5);
            SpawnForEachPointTheCoins(4, spawnPoints[13].transform, 2, 3);
            SpawnForEachPointTheCoins(3, spawnPoints[14].transform, 2, 3);
            SpawnForEachPointTheCoins(1, spawnPoints[15].transform, 2, 3);
            SpawnForEachPointTheCoins(1, spawnPoints[16].transform, 2, 4);
            SpawnForEachPointTheCoins(1, spawnPoints[17].transform, 2, 30);
            SpawnForEachPointTheCoins(1, spawnPoints[18].transform, 5, 6);
            SpawnForEachPointTheCoins(1, spawnPoints[19].transform, 5, 6);
            SpawnForEachPointTheCoins(3, spawnPoints[20].transform, 2, 3);
            SpawnForEachPointTheCoins(4, spawnPoints[21].transform, 2, 3);
            SpawnForEachPointTheCoins(1, spawnPoints[22].transform, 5, 6);
            SpawnForEachPointTheCoins(1, spawnPoints[23].transform, 5, 6);
            SpawnForEachPointTheCoins(3, spawnPoints[24].transform, 2, 3);
            SpawnForEachPointTheCoins(4, spawnPoints[25].transform, 2, 3);
            SpawnForEachPointTheCoins(3, spawnPoints[26].transform, 2, 3);
            SpawnForEachPointTheCoins(1, spawnPoints[27].transform, 2, 10);
            SpawnForEachPointTheCoins(1, spawnPoints[28].transform, 2, 10);
            SpawnForEachPointTheCoins(1, spawnPoints[29].transform, 2, 30);
        }
    }

    

    void SpawnForEachPointTheCoins(int typeSpawn, Transform s, int distanceBetweenCoins, int numCoinsForRow)
    {        
        SpawnTrans = s.transform;
        coin.SpawnCoins(typeSpawn, SpawnTrans, distanceBetweenCoins, numCoinsForRow);

    }
}
