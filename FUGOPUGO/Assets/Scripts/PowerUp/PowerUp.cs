using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [SerializeField] protected GameObject targetPlayer;
    [SerializeField] protected GameObject targetPowerUpCoroutine;
    [SerializeField] protected PowerUpCoroutine script;
    [SerializeField] protected Text textPowerUp;
    [SerializeField] protected float durationPowerUp;
    private void Start()
    {
        targetPlayer = GameObject.Find("Player");

        if (GameObject.Find("PowerUpCoroutine"))
        {
            targetPowerUpCoroutine = GameObject.Find("PowerUpCoroutine");
            script = targetPowerUpCoroutine.GetComponent<PowerUpCoroutine>();
        }
        else
        {
            targetPowerUpCoroutine = new GameObject();
            targetPowerUpCoroutine.name = "PowerUpCoroutine";
            targetPowerUpCoroutine.AddComponent<PowerUpCoroutine>();
            script = targetPowerUpCoroutine.GetComponent<PowerUpCoroutine>();
        }
        OnStart();
    }


    protected virtual void OnStart()
    {

    }
    public virtual IEnumerator InvokePowerUp()
    {
        yield return 0;
    }


}
