using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin: MonoBehaviour
{

    [SerializeField] private GameObject CoinManager;
    [SerializeField] private GameObject objectPooler;

    [SerializeField] private int valueCoin;
    [SerializeField] private string nameCoin;
    
    [SerializeField] private float moveSpeedCoin;
    [SerializeField] CoinMovement coinMovement;
    public Transform playerTransform;

    public int ValueCoin
    {
        get { return valueCoin; }
        set { valueCoin = value; }
    }

    public string NameCoin
    {
        get { return nameCoin; }
        set { nameCoin = value; }
    }

    public float MoveSpeedCoin
    {
        get { return moveSpeedCoin; }
        set { moveSpeedCoin = value; }
    }

    private void Start()
    {
        CoinManager = GameObject.Find("CoinManager");
        objectPooler = GameObject.Find("ObjectPooler");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinMovement = gameObject.GetComponent<CoinMovement>();
        MoveSpeedCoin = 40f;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Se entro in collisione con il detector del player.
        if(other.gameObject.tag == "Coin Detector")
        {
            Debug.Log("Ho colliso con " + other.name);
            coinMovement.enabled = true;
        }

        //Se entro in collisione con il player, inserisco la moneta raccolta nel coin manager e la inserisco nel pool.
        if (other.gameObject.layer == 9)
        {

            gameObject.transform.parent.gameObject.SetActive(false);
            //this.gameObject.SetActive(false);
            SoundManager.Instance.CoinSound();
            CoinManager.GetComponent<CoinManager>().AddCoins(this.GetComponent<Coin>().ValueCoin);
            objectPooler.GetComponent<ObjectPooler>().EnqueuePooled("Marscoin", gameObject.transform.parent.gameObject);

        }
    }


}
