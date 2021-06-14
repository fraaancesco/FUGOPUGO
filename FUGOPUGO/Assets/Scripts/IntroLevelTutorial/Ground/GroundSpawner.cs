using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    [SerializeField] private GameObject objectPooler;
    [SerializeField] private GameObject targetPlayer;
    [SerializeField] private GameObject groundTile;
    [SerializeField] private Vector3 nextSpawn;
    public LinkedList<GameObject> listGroundTile;
    private string typeGround = "Ground";
    [SerializeField] private float zSpawn;
    [SerializeField] private int lenghtGround;
    [SerializeField] private int numOfTiles;


    private void Start()
    {
        targetPlayer = GameObject.Find("Player");
        listGroundTile = new LinkedList<GameObject>();

        zSpawn = 0;
        lenghtGround = 10;

        if(listGroundTile.Count == 0)
        {    
            for(int i = 0; i < numOfTiles; i++) { 
                SpawnTile();
            }
        }
        listGroundTile.First.Value.transform.GetChild(3).gameObject.SetActive(true);
        numOfTiles = listGroundTile.Count;
    }

    private void Update()
    {

        if (targetPlayer.transform.position.z - lenghtGround * 2 > zSpawn - (numOfTiles * lenghtGround))
        {
            SpawnTile();
            objectPooler.GetComponent<ObjectPooler>().EnqueuePooled("Ground", listGroundTile.First.Value as GameObject);
            listGroundTile.First.Value.gameObject.SetActive(false);
            listGroundTile.First.Value.transform.GetChild(3).gameObject.SetActive(false);
            listGroundTile.RemoveFirst();
            listGroundTile.First.Value.transform.GetChild(3).gameObject.SetActive(true);
        }
    }

    public void SpawnTile()
    {
        nextSpawn = transform.forward * zSpawn;
        groundTile = objectPooler.GetComponent<ObjectPooler>().getPooledObject(typeGround);
        groundTile.transform.Spawn(nextSpawn);
        listGroundTile.AddLast(groundTile as GameObject);
        zSpawn += lenghtGround;
    }
}
