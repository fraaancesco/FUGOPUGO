using UnityEngine;

public class Coin: MonoBehaviour
{

    [SerializeField] private GameObject CoinManager;
    [SerializeField] private GameObject ObjectPooler;

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
        ObjectPooler = GameObject.Find("ObjectPooler");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        coinMovement = gameObject.GetComponent<CoinMovement>();
        MoveSpeedCoin = 40f;
    }

    private void OnTriggerEnter(Collider other)
    {
        // If collide with the  player's coin detector.
        if(other.gameObject.tag == "Coin Detector")
        {
            Debug.Log("Ho colliso con " + other.name);
            coinMovement.enabled = true;
        }

        // If collide with player, add the coin on the pool.
        if (other.gameObject.layer == 9)
        {

            gameObject.transform.parent.gameObject.SetActive(false);
            //this.gameObject.SetActive(false);
            SoundManager.Instance.CoinSound();
            CoinManager.GetComponent<CoinManager>().AddCoins(this.GetComponent<Coin>().ValueCoin);
            ObjectPooler.GetComponent<ObjectPooler>().EnqueuePooled("Marscoin", gameObject.transform.parent.gameObject);

        }
    }


}
