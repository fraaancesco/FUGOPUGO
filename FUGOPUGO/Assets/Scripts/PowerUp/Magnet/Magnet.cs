using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magnet : PowerUp
{

    [SerializeField] private GameObject targetCoinDetector;
    [SerializeField] private GameObject MagnetCanvas;
    protected override void OnStart()
    {
        if (GameObject.Find("Canvas/PowerUps/Magnet"))
        {
            MagnetCanvas = GameObject.Find("Canvas/PowerUps/Magnet");
            textPowerUp = GameObject.Find("Canvas/PowerUps/Magnet/TextMagnet").gameObject.GetComponent<Text>();
        }
        else
        {
            Debug.Log("GameObject PowerUp non trovato");
        }

        if (GameObject.Find("Player"))
        {
            targetCoinDetector = GameObject.Find("Player").gameObject.transform.Find("CoinDetectorPlayer").gameObject;
        }
        else
        {
            Debug.Log("Coin Detector non trovato");
        }


        if (targetCoinDetector.activeSelf)
        {
            targetCoinDetector.SetActive(false);
        }

        timeEffectPowerUp = 0;
        durationPowerUp = 20f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            script.ActiveCoroutineMagnet(gameObject);
            SoundManager.Instance.PowerUps("Magnet");
        }
    }
    
    public override IEnumerator InvokePowerUp()
    {
        timeEffectPowerUp = durationPowerUp;
        MagnetCanvas.SetActive(true);
        while (timeEffectPowerUp > 0f)
        {
            targetCoinDetector.SetActive(true);
            if (timeEffectPowerUp > 0)
            {
                timeEffectPowerUp -= Time.deltaTime;
                textPowerUp.text = Mathf.Round(timeEffectPowerUp).ToString();
            }
            yield return 0;
            targetCoinDetector.SetActive(false);
        }
        MagnetCanvas.SetActive(false);
    }
}
