using UnityEngine;

public class PowerUpCoroutine : MonoBehaviour
{
    [SerializeField] private GameObject objectPooler;
    public bool magnetIsActive;
    public bool resizeScaleIsActive;
    public bool upWeightIsActive;
    public float timeMagnet;
    public float timeResizeScale;
    public float timeUpWeight;
    

    private void Awake()
    {
        objectPooler = GameObject.Find("ObjectPooler");
        magnetIsActive = false;
        resizeScaleIsActive = false;
        upWeightIsActive = false;
    }


    public void ActiveCoroutineMagnet(GameObject obj, float timePowerUp)
    {
        Magnet script = obj.GetComponent<Magnet>();
        obj.transform.parent.gameObject.SetActive(false);
        timeMagnet = timePowerUp;
        StartCoroutine(script.InvokePowerUp());
        // objectPooler.GetComponent<ObjectPooler>().EnqueuePooled("Magnet", obj.transform.parent.gameObject);
        Destroy(obj.transform.parent.gameObject);
    }

    public void ActiveCoroutineResizeScale(GameObject obj, float timePowerUp)
    {
        ResizeScale script = obj.GetComponent<ResizeScale>();
        obj.transform.parent.gameObject.SetActive(false);
        StartCoroutine(script.InvokePowerUp());
        //  objectPooler.GetComponent<ObjectPooler>().EnqueuePooled("ResizeScale", obj.transform.parent.gameObject);
        Destroy(obj.transform.parent.gameObject);
    }

    public void ActiveCoroutineUpWeight(GameObject obj, float timePowerUp)
    {
        UpWeight script = obj.GetComponent<UpWeight>();
        obj.transform.parent.gameObject.SetActive(false);
        StartCoroutine(script.InvokePowerUp());
        // objectPooler.GetComponent<ObjectPooler>().EnqueuePooled("UpWeight", obj.transform.parent.gameObject);
        Destroy(obj.transform.parent.gameObject);
    }
}
