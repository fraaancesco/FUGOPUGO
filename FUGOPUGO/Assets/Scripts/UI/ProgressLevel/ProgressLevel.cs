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

    public float DistanceFinal
    {
        get { return distanceFinal; }
        set { distanceFinal = value; }
    }

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
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

        distanceFinal = positionEndLevel.z - positionPlayer.z;
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
