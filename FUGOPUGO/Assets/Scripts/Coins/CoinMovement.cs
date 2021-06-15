using UnityEngine;

public class CoinMovement : MonoBehaviour
{

    private Coin coin;

    void Start()
    {
        coin = gameObject.GetComponent<Coin>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, coin.playerTransform.position, coin.MoveSpeedCoin * Time.deltaTime);
    }

}
