using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCoroutine : MonoBehaviour
{
    [SerializeField] private GameObject objectPooler;
    private void Awake()
    {
        objectPooler = GameObject.Find("ObjectPooler");   
    }

    #region NOTE
    // L'attivazione delle coroutines e' stata messa qui, perché dopo aver raccolto l'oggetto ( magnete,resizescale,upheight ), vogliamo renderli non più attivi.
    // Se avessimo messo tutto in uno script la coroutine non avrebbe mai terminato, dato che avremmo settato l'oggetto a false, dopo averlo raccolto.
    // Quindi si utilizza un oggetto vuoto che gestisce l'attivazione/disattivazione degli oggetti e l'attivazione delle varie coroutines.
    #endregion

    public void ActiveCoroutineMagnet(GameObject obj)
    {
        Magnet script = obj.GetComponent<Magnet>();
        obj.transform.parent.gameObject.SetActive(false);
        StartCoroutine(script.InvokePowerUp());
        // objectPooler.GetComponent<ObjectPooler>().EnqueuePooled("Magnet", obj.transform.parent.gameObject);
        Destroy(obj.transform.parent.gameObject);
    }

    public void ActiveCoroutineResizeScale(GameObject obj)
    {
        ResizeScale script = obj.GetComponent<ResizeScale>();
        obj.transform.parent.gameObject.SetActive(false);
        StartCoroutine(script.InvokePowerUp());
        //  objectPooler.GetComponent<ObjectPooler>().EnqueuePooled("ResizeScale", obj.transform.parent.gameObject);
        Destroy(obj.transform.parent.gameObject);
    }

    public void ActiveCoroutineUpWeight(GameObject obj)
    {
        UpWeight script = obj.GetComponent<UpWeight>();
        obj.transform.parent.gameObject.SetActive(false);
        StartCoroutine(script.InvokePowerUp());
        //objectPooler.GetComponent<ObjectPooler>().EnqueuePooled("UpWeight", obj.transform.parent.gameObject);
        Destroy(obj.transform.parent.gameObject);
    }
}
