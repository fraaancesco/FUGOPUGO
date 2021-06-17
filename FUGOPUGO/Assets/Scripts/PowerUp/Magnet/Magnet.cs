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
            Debug.Log("PowerUp not found");
        }

        if (GameObject.Find("Player"))
        {
            targetCoinDetector = GameObject.Find("Player").gameObject.transform.Find("CoinDetectorPlayer").gameObject;
        }
        else
        {
            Debug.Log("Coin Detector not found");
        }


        if (targetCoinDetector.activeSelf)
        {
            targetCoinDetector.SetActive(false);
        }

        durationPowerUp = 20f;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!script.magnetIsActive) 
            {
                script.ActiveCoroutineMagnet(gameObject, durationPowerUp);
            }
            else
            {
                script.timeMagnet += durationPowerUp;
                this.transform.parent.gameObject.SetActive(false);
                Destroy(this.transform.parent.gameObject);
            }
            SoundManager.Instance.PowerUps("Magnet");
        }
    }
    
    public override IEnumerator InvokePowerUp()
    {
        script.timeMagnet = durationPowerUp;
        script.magnetIsActive = true;
        MagnetCanvas.SetActive(true);
        while (script.timeMagnet > 0f)
        {
            targetCoinDetector.SetActive(true);
            if (script.timeMagnet > 0)
            {
                script.timeMagnet -= Time.deltaTime;
                textPowerUp.text = Mathf.Round(script.timeMagnet).ToString();
            }
            yield return 0;
            targetCoinDetector.SetActive(false);
        }
        script.magnetIsActive = false;
        MagnetCanvas.SetActive(false);
    }
}
