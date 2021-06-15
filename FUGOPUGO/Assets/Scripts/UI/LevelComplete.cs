using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    private GameObject canvas;
    [SerializeField] private GameObject levelComplete;
    [SerializeField] private GameObject oldScore;
    [SerializeField] private GameObject newScore;
    [SerializeField] private GameObject timeRemain;
    [SerializeField] private GameObject coinsCollected;
    [SerializeField] private GameObject finalScore;

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        levelComplete = canvas.transform.Find("LevelComplete").gameObject;
        oldScore = levelComplete.transform.Find("OldScore/TextOldScore").gameObject;
        newScore = levelComplete.transform.Find("NewScore/TextNewScore").gameObject;
        timeRemain = levelComplete.transform.Find("TimeRemain/TextTimeRemain").gameObject;
        coinsCollected = levelComplete.transform.Find("CoinsCollected/TextCoinsCollected").gameObject;
        finalScore = levelComplete.transform.Find("FinalScore/TextFinalScore").gameObject;
    }

    public void SetLevelComplete()
    {
        float scorePlayer = (float)canvas.GetComponent<ScorePlayer>().GetScorePlayer();
        newScore.GetComponent<Text>().text = Mathf.Round(scorePlayer).ToString();

        string timeRemainPlayer = canvas.GetComponent<ScorePlayer>().GetRemainTime();
        timeRemain.GetComponent<Text>().text = timeRemainPlayer;

        int coinsCollectedOfLvl= GameObject.Find("CoinManager").GetComponent<CoinManager>().GetCoinsOfLevel();
        coinsCollected.GetComponent<Text>().text = coinsCollectedOfLvl.ToString();

        // Set old score.
        double oldScorePlayer = SaveGame.GetScoreLevel(SceneManager.GetActiveScene().buildIndex - 2);
       
        oldScore.GetComponent<Text>().text = oldScorePlayer.ToString();

        // Set final score.
        float finalScorePlayer = (float)canvas.GetComponent<ScorePlayer>().CalculateScore();
        finalScore.GetComponent<Text>().text = Mathf.Round(finalScorePlayer).ToString();
   }
}
