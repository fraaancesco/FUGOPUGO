using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ProgressLevel : MonoBehaviour
{
    [SerializeField] private GameObject targetPlayer;
    [SerializeField] private Vector3 positionPlayer;

    [SerializeField] private GameObject endLevel;
    [SerializeField] private GameObject startLevel;
    [SerializeField] private Vector3 positionStartLevel;
    [SerializeField] private Vector3 positionEndLevel;
    [SerializeField] private float distanceToEndLevel;
    [SerializeField] private float distanceFinal;
    [SerializeField] private Slider slider;
    [SerializeField] private ParticleSystem partSystem;
    private float targetLevelProgress = 0;
    private float FillSpeed = 0.5f;


    public float DistanceFinal
    {
        get { return distanceFinal; }
        set { distanceFinal = value; }
    }

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        //partSystem = GameObject.Find("ProgressLevel Bar Particles").GetComponent<ParticleSystem>();
    }

    void Start()
    {

        targetPlayer = GameObject.Find("Player");
        positionPlayer = targetPlayer.transform.position;

        endLevel = GameObject.Find("End");
        positionEndLevel = endLevel.transform.position;

        startLevel = GameObject.Find("Start");
        positionStartLevel = startLevel.transform.position;

        slider.minValue = positionStartLevel.z;
        slider.maxValue = positionEndLevel.z;

        distanceFinal = Mathf.Round(Mathf.Sqrt(Mathf.Pow(positionEndLevel.x - positionStartLevel.x, 2) + Mathf.Pow(positionEndLevel.y - positionStartLevel.y, 2) + Mathf.Pow(positionEndLevel.z - positionStartLevel.z,2 )));
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "IntroLevel")
        {
            positionEndLevel = endLevel.transform.position;
            distanceFinal = positionEndLevel.z - positionPlayer.z;
        }
        else
        {
            positionPlayer = targetPlayer.transform.position;
            distanceToEndLevel = distanceFinal - positionPlayer.z;
            IncrementProgressLevel(distanceToEndLevel);
        }
    }


    public void IncrementProgressLevel(float newProgress)
    {
        slider.value = slider.maxValue - newProgress;
    }

}
