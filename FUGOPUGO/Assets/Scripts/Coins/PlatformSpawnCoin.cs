using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlatformSpawnCoin : MonoBehaviour
{
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private CoinGenerator coin;
    [SerializeField] private List<GameObject> spawnPoints;
    private Transform SpawnTrans;


    private void Awake()
    {
        spawnPoint = GameObject.Find("PointSpawnCoins");
        coin = GameObject.Find("SpawnCoins").GetComponent<CoinGenerator>();
        spawnPoints = new List<GameObject>(); 

        // Find all spawns.
        if (SceneManager.GetActiveScene().buildIndex >= 2) 
        {
            for (int i = 0; i < spawnPoint.transform.childCount; i++)
            {
                spawnPoints.Add(spawnPoint.transform.GetChild(i).gameObject);
            }
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

        // Level 02
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            SpawnForEachPointTheCoins(1, spawnPoints[0].transform, 2, 10);
            SpawnForEachPointTheCoins(2, spawnPoints[1].transform, 2, 3);
            SpawnForEachPointTheCoins(1, spawnPoints[2].transform, 2, 20);
            SpawnForEachPointTheCoins(1, spawnPoints[3].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[4].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[5].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[6].transform, 3, 20);
            SpawnForEachPointTheCoins(1, spawnPoints[7].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[8].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[9].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[10].transform, 5, 5);
            SpawnForEachPointTheCoins(3, spawnPoints[11].transform, 2, 3);
            SpawnForEachPointTheCoins(1, spawnPoints[12].transform, 2, 3);
            SpawnForEachPointTheCoins(4, spawnPoints[13].transform, 2, 3);
            SpawnForEachPointTheCoins(3, spawnPoints[14].transform, 2, 3);
           // SpawnForEachPointTheCoins(1, spawnPoints[15].transform, 2, 3);
        }

        // Level 03
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            SpawnForEachPointTheCoins(1, spawnPoints[0].transform, 2, 10);
            SpawnForEachPointTheCoins(4, spawnPoints[1].transform, 1, 3);
            SpawnForEachPointTheCoins(1, spawnPoints[2].transform, 2, 4);
            SpawnForEachPointTheCoins(4, spawnPoints[3].transform, 2, 5);
            SpawnForEachPointTheCoins(1, spawnPoints[4].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[5].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[6].transform, 3, 20);
            SpawnForEachPointTheCoins(1, spawnPoints[7].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[8].transform, 3, 30);
            SpawnForEachPointTheCoins(1, spawnPoints[9].transform, 2, 7);
            SpawnForEachPointTheCoins(1, spawnPoints[10].transform, 5, 5);
            SpawnForEachPointTheCoins(1, spawnPoints[11].transform, 4, 50);
            SpawnForEachPointTheCoins(1, spawnPoints[12].transform, 2, 3);
            SpawnForEachPointTheCoins(4, spawnPoints[13].transform, 2, 3);
            SpawnForEachPointTheCoins(4, spawnPoints[14].transform, 2, 3);
            SpawnForEachPointTheCoins(1, spawnPoints[15].transform, 2, 3);
            SpawnForEachPointTheCoins(1, spawnPoints[16].transform, 3, 30);
            SpawnForEachPointTheCoins(1, spawnPoints[17].transform, 2, 3);

        }
    }

    

    void SpawnForEachPointTheCoins(int typeSpawn, Transform s, int distanceBetweenCoins, int numCoinsForRow)
    {        
        SpawnTrans = s.transform;
        coin.SpawnCoins(typeSpawn, SpawnTrans, distanceBetweenCoins, numCoinsForRow);

    }
}
