using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScorePlayer : MonoBehaviour
{
    [SerializeField] private Text timeRemainCanvas;
    [SerializeField] private Text scoreText;
    [SerializeField] private Vector3 lastPositionPlayer;
    [SerializeField] private List<float> timerLevel;
    private float timer;
    public Transform playerMov;
    public double scorePlayer;
    bool timeIsRunning;
    private void Start()
    {
        timeRemainCanvas = GameObject.Find("Canvas/TimeToFinish").GetComponent<Text>();  
        playerMov = GameObject.Find("Player").gameObject.transform;
        scoreText = GameObject.Find("Score").gameObject.GetComponent<Text>();
        lastPositionPlayer = playerMov.position;

        scorePlayer = 0;
        timerLevel = new List<float>();
        
        // Timer first level.
        timerLevel.Add(180);

        // Timer second level.
        timerLevel.Add(180);

        // Timer third level.
        timerLevel.Add(180);

        LoadTimer();
        timeIsRunning = true;
    }

    void Update()
    {
        UpdateScoreUI();
        UpdateTimeRemainUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText.IsActive())
        {
            SetScorePlayer();

            // Set a limit for UI Score.
            if (scorePlayer <= 9999999)
            {
                scoreText.text = scorePlayer.ToString("0");
            }
            else
            {
                scoreText.text = 9999999.ToString("0") + "+";
            }
        }
    }

    private void UpdateTimeRemainUI()
    {
        if (timeIsRunning)
        {

            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }
            else
            {
                timer = 0;
                timeIsRunning = false;
            }

            DisplayTime();
        }
    }

    private void SetScorePlayer()
    {
        if (playerMov.position.z > lastPositionPlayer.z) { 
            scorePlayer += (playerMov.position.z * 0.001);
            lastPositionPlayer = playerMov.position;
        }
    }

    

    private void DisplayTime()
    {
        timeRemainCanvas.text = GetRemainTime();
    }



    private void LoadTimer()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;

        switch (indexScene)
        {
            case 2:
                timer = timerLevel[0];
                break;

            case 3:
                timer = timerLevel[1];
                break;

            case 4:
                timer = timerLevel[2];
                break;

            default:
                break;
        }
    }

    public double CalculateScore()
    {
        int indexScene = SceneManager.GetActiveScene().buildIndex;
        switch (indexScene)
        {
            case 2:
                if (timer >= 120 && timer <= 180)
                    return scorePlayer * 1.5;
                if (timer >= 60 && timer < 120)
                    return scorePlayer * 1.3;
                if (timer >= 0 && timer < 60)
                    return scorePlayer * 1.1;
                break;

            case 3:
                if (timer >= 120 && timer <= 180)
                    return scorePlayer * 1.5;
                if (timer >= 60 && timer < 120)
                    return scorePlayer * 1.3;
                if (timer >= 0 && timer < 60)
                    return scorePlayer * 1.1;
                break;

            case 4:
                if (timer >= 120 && timer <= 180)
                    return scorePlayer * 1.5;
                if (timer >= 60 && timer < 120)
                    return scorePlayer * 1.3;
                if (timer >= 0 && timer < 60)
                    return scorePlayer * 1.1;
                break;
            default:
                break;

        }
        return scorePlayer;
    }

    public string GetRemainTime()
    {
        float min = Mathf.FloorToInt(timer / 60);
        float sec = Mathf.FloorToInt(timer % 60);
        return  string.Format("{0:00}:{1:00}", min, sec);
    }

    public double GetScorePlayer()
    {
        return scorePlayer;
    }
}
