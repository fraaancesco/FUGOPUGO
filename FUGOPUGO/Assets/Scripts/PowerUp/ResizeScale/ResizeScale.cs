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
            Debug.Log(" PowerUp not found");
        }

        scaleResizePlayer = new Vector3(0.5f,0.5f,0.5f);
        speedPlayer = targetPlayer.GetComponent<PlayerMovement>().ZForce;
        scalePlayer = targetPlayer.transform.localScale;
        speedResizePlayer = speedPlayer * 2;

        durationPowerUp = 20;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (!script.resizeScaleIsActive)
            {
                script.ActiveCoroutineResizeScale(gameObject, durationPowerUp);

            }
            else
            {
                script.timeResizeScale += durationPowerUp;
                this.transform.parent.gameObject.SetActive(false);
                Destroy(this.transform.parent.gameObject);
            }
            SoundManager.Instance.PowerUps("ResizeScale");
        }
    }

    public override IEnumerator InvokePowerUp()
    {
        script.timeResizeScale = durationPowerUp;
        script.resizeScaleIsActive = true;
        ResizeScaleCanvas.SetActive(true);
        while (script.timeResizeScale > 0f)
        {
            targetPlayer.transform.localScale = scaleResizePlayer;
            targetPlayer.GetComponent<PlayerMovement>().ZForce = speedResizePlayer;

            if (script.timeResizeScale > 0)
            {
                script.timeResizeScale -= Time.deltaTime;
                textPowerUp.text = Mathf.Round(script.timeResizeScale).ToString();
            }
            yield return 0;
            targetPlayer.transform.localScale = scalePlayer;
            targetPlayer.GetComponent<PlayerMovement>().ZForce = speedPlayer;
        }
        ResizeScaleCanvas.SetActive(false);
        script.resizeScaleIsActive = false;
    }
}
