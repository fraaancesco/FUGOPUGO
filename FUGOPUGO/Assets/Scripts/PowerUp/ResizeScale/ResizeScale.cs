using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeScale : PowerUp
{
    [SerializeField] private GameObject ResizeScaleCanvas;
    [SerializeField] private Vector3 scalePlayer;
    [SerializeField] private Vector3 scaleResizePlayer;
    [SerializeField] private float speedPlayer;
    [SerializeField] private float speedResizePlayer;


    protected override void OnStart()
    {
        if (GameObject.Find("Canvas/PowerUps/ResizeScale"))
        {
            ResizeScaleCanvas = GameObject.Find("Canvas/PowerUps/ResizeScale");
            textPowerUp = GameObject.Find("Canvas/PowerUps/ResizeScale/TextResizeScale").gameObject.GetComponent<Text>();
        }
        else
        {
            Debug.Log("GameObject PowerUp non trovato");
        }

        scaleResizePlayer = new Vector3(0.5f,0.5f,0.5f);
        speedPlayer = targetPlayer.GetComponent<PlayerMovement>().ZForce;
        scalePlayer = targetPlayer.transform.localScale;
        speedResizePlayer = speedPlayer * 2;

        timeEffectPowerUp = 0;
        durationPowerUp = 20;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            script.ActiveCoroutineResizeScale(gameObject);
            SoundManager.Instance.PowerUps("ResizeScale");
        }
    }

    public override IEnumerator InvokePowerUp()
    {
        timeEffectPowerUp = durationPowerUp;

        ResizeScaleCanvas.SetActive(true);
        while (timeEffectPowerUp > 0f)
        {
            targetPlayer.transform.localScale = scaleResizePlayer;
            targetPlayer.GetComponent<PlayerMovement>().ZForce = speedResizePlayer;

            if (timeEffectPowerUp > 0)
            {
                timeEffectPowerUp -= Time.deltaTime;
                textPowerUp.text = Mathf.Round(timeEffectPowerUp).ToString();
            }
            yield return 0;
            targetPlayer.transform.localScale = scalePlayer;
            targetPlayer.GetComponent<PlayerMovement>().ZForce = speedPlayer;
        }
        ResizeScaleCanvas.SetActive(false);

    }
}
