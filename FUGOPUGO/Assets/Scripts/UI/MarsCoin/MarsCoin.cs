using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarsCoin : MonoBehaviour
{
    
    [SerializeField] private Text numberMarscoin;
    [SerializeField] private GameObject coinManager;
    void Start()
    {
        coinManager = GameObject.Find("CoinManager");
    }

    void Update()
    {
        numberMarscoin.text = coinManager.GetComponent<CoinManager>().coins[0].value.ToString();
    }
}
