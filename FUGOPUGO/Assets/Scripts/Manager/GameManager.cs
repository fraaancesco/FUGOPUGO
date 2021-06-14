using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : Singleton<GameManager>
{

    [SerializeField] GameObject completeLevelUI;
    [SerializeField] GameObject canvas;
    [SerializeField] GameObject deathUI;
    [SerializeField] GameObject coinManager;
    [SerializeField] GameObject marscoin;
    [SerializeField] GameObject score;
    [SerializeField] GameObject progressLevelBar;
    [SerializeField] GameObject timeToFinish;
    [SerializeField] GameObject powerup;

    private int sceneIndex, levelPassed;
    public bool gameHasEnded = false;
    public float restartDelay = 2f;
    public bool stopGame;
    public static PlayerData playerinfo = new PlayerData();

    private string nameToSearch;
    public string filePathSetting = "Assets/Json/PlayerList.json";

    [SerializeField] InputField input;
    [SerializeField] GameObject level01, level02, level03;
    Button level01btn, level02btn, level03btn;

    public ScoreManager scoreManager;
    private void Awake()
    {
        coinManager = GameObject.Find("CoinManager");
        stopGame = false;
        if(SceneManager.GetActiveScene().buildIndex >= 1 && SceneManager.GetActiveScene().buildIndex < 5)
        {
            canvas = GameObject.Find("Canvas");
            score = canvas.transform.Find("Score").gameObject;
            marscoin = GameObject.Find("MarsCoin");
            progressLevelBar = GameObject.Find("ProgressLevel");
            timeToFinish = GameObject.Find("TimeToFinish");
            deathUI = canvas.transform.Find("Death").gameObject;
            completeLevelUI = canvas.transform.Find("LevelComplete").gameObject;
            powerup = canvas.transform.Find("PowerUps").gameObject;
        }
    }

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = SaveGame.GetLevelPassed();
        coinManager.GetComponent<CoinManager>().ResetCoins();
    }


    private void Update()
    {
        TimeFreeze();
    }

    public void TimeFreeze()
    {
        if (stopGame) 
        { 
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                //AudioListener.pause = true;
            }
            else
            {
                Time.timeScale = 1;
                //AudioListener.pause = false;
            }
        }
    }


    public void CompleteLevel() 
    {
        SetFalseUserUI();
        stopGame = true;
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            completeLevelUI.SetActive(true);
            canvas.GetComponent<LevelComplete>().SetLevelComplete();
         
            double points = canvas.GetComponent<ScorePlayer>().CalculateScore();
            SaveGame.SaveScoreLevel(points);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1) //implentare UI TUTORIAL
            LoadNextLevel();
        SaveGame.SaveLevel(sceneIndex);
        double finalScore = 0;
        if (sceneIndex == 4)
        {
            for (int i = 0; i < 3; i++) { 
                finalScore += SaveGame.GetScoreLevel(i);
            }
            scoreManager.AddScore(new Score(playerinfo.namePlayer,finalScore)); 
            scoreManager.SaveScore();
        }

        coinManager.GetComponent<CoinManager>().SaveCoins();
        coinManager.GetComponent<CoinManager>().ResetCoins();
        

    }
    public void EndGame()
    {
        if (gameHasEnded == false) 
        {
            stopGame = true;
            gameHasEnded = true;
            deathUI.SetActive(true);
            // Set false UI player
            SetFalseUserUI();
        }
    }

    public void LoadMainMenu() 
    {
        AsyncOperation op = SceneManager.LoadSceneAsync("Menu");
    }

    public void LoadNextLevel()
    {
        coinManager.GetComponent<CoinManager>().ResetCoins();
        AsyncOperation op = SceneManager.LoadSceneAsync(sceneIndex + 1);
    }

    public void RestartGame()
    {
       
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void SetupPlayer()
    {

        nameToSearch = input.text;
        playerinfo = SaveData.FindPlayer(filePathSetting, nameToSearch);
        if (playerinfo.namePlayer == null)
        {
           
            playerinfo.namePlayer = nameToSearch;
            playerinfo.wallet = 0;
            for (int i = 0; i < 3; i++)
                playerinfo.score[i] = 0;
            playerinfo.levelPassed = 0;
            playerinfo.IndexSkin = 0;
            playerinfo.skinUnlocked[0] = true;
            for (int i = 1; i < 4; i++)
                playerinfo.skinUnlocked[i] = false;

            SaveData.AddPlayerData(playerinfo);
            SaveData.Save(filePathSetting, SaveData.playerContainer);
        }
       
    }

    public void SetFalseUserUI()
    {
        score.SetActive(false);
        timeToFinish.SetActive(false);
        progressLevelBar.SetActive(false);
        marscoin.SetActive(false);
        powerup.SetActive(false);
    }


    public void LoadLevelAvailable()
    {
        level01btn = level01.GetComponent<Button>();
        level02btn = level02.GetComponent<Button>();
        level03btn = level03.GetComponent<Button>();
        ResetLevel();
        levelPassed = playerinfo.levelPassed;
        switch (levelPassed)
        {
            case 1:
                level01btn.interactable = true;
                level01.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Text/Level1") as Sprite;
                break;
            case 2:
                level02.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Text/Level2") as Sprite;
                level01.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Text/Level1") as Sprite;
                level01btn.interactable = true;
                level02btn.interactable = true;
                break;
            case 3:
                level03.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Text/Level3") as Sprite;
                level02.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Text/Level2") as Sprite;
                level01.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Text/Level1") as Sprite;
                level01btn.interactable = true;
                level02btn.interactable = true;
                level03btn.interactable = true;
                break;
        }
    }

    public void LevelToLoad(int level)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(level);
    }

    public void ResetLevel()
    {
        level03.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Text/Level3-check") as Sprite;
        level02.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Text/Level2-check") as Sprite;
        level01.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/Text/Level1-check") as Sprite;
        level01btn.interactable = false;
        level02btn.interactable = false;
        level03btn.interactable = false;
    }

}