using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpWeight : PowerUp
{
    [SerializeField] private GameObject UpWeightCanvas;
    private Rigidbody rigidBodyPlayer;
    private float weightPlayer;
    private float upWeightPlayer;

    protected override void OnStart()
    {
        if (GameObject.Find("Canvas/PowerUps/UpWeight"))
        {
            UpWeightCanvas = GameObject.Find("Canvas/PowerUps/UpWeight");
            textPowerUp = GameObject.Find("Canvas/PowerUps/UpWeight/TextUpWeight").gameObject.GetComponent<Text>();
        }
        else
        {
            Debug.Log("PowerUp not found");
        }

        rigidBodyPlayer = GameObject.Find("Player").GetComponent<Rigidbody>();
        weightPlayer = rigidBodyPlayer.drag;

        timeEffectPowerUp = 0;
        durationPowerUp = 10f;

        upWeightPlayer = 10;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            script.ActiveCoroutineUpWeight(this.gameObject);
            SoundManager.Instance.PowerUps("UpWeight");
        }
    }

    public override IEnumerator InvokePowerUp()
    {
        timeEffectPowerUp = durationPowerUp;
        UpWeightCanvas.SetActive(true);
        while (timeEffectPowerUp > 0f)
        {
            rigidBodyPlayer.drag = upWeightPlayer;
            if (timeEffectPowerUp > 0)
            {
                timeEffectPowerUp -= Time.deltaTime;
                textPowerUp.text = Mathf.Round(timeEffectPowerUp).ToString();
            }
            yield return 0;
            rigidBodyPlayer.drag = weightPlayer;
        }
        UpWeightCanvas.SetActive(false);
    }
}
