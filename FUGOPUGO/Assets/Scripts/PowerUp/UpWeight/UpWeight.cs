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

        durationPowerUp = 10f;

        upWeightPlayer = 10;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(!script.upWeightIsActive)
            {
                script.ActiveCoroutineUpWeight(this.gameObject, durationPowerUp);
            }
            else
            {
                script.timeUpWeight += durationPowerUp;
                this.transform.parent.gameObject.SetActive(false);
                Destroy(this.transform.parent.gameObject);
            }
            SoundManager.Instance.PowerUps("UpWeight");
        }
    }

    public override IEnumerator InvokePowerUp()
    {
        script.timeUpWeight = durationPowerUp;
        script.upWeightIsActive = true;
        UpWeightCanvas.SetActive(true);
        while (script.timeUpWeight > 0f)
        {
            rigidBodyPlayer.drag = upWeightPlayer;
            if (script.timeUpWeight > 0)
            {
                script.timeUpWeight -= Time.deltaTime;
                textPowerUp.text = Mathf.Round(script.timeUpWeight).ToString();
            }
            yield return 0;
            rigidBodyPlayer.drag = weightPlayer;
        }
        script.upWeightIsActive = false;
        UpWeightCanvas.SetActive(false);
    }
}
