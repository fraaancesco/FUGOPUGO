using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject IntroLevel;
    [SerializeField] private GameObject TextTutorial;
    [SerializeField] private GameObject ProgressLevel;
    [SerializeField] private GameObject MarsCoin;
    [SerializeField] private GameObject PowerUps;
    [SerializeField] private GameObject TimeToFinish;
    [SerializeField] private GameObject Score;
    [SerializeField] private GameObject Handle;

    [SerializeField] private string[] TutorialStep;
    [SerializeField] private string[] DialogProgressBar;
    [SerializeField] Text TutorialStepText;
    [SerializeField] Text DialogProgressText;

    [SerializeField] private GameObject ObjectPooler;
    [SerializeField] private GameObject TargetPlayer;
    [SerializeField] private Vector3 OffsetGround;
    [SerializeField] private Vector3 SpawnPositionBehindPlayer;
    List<GameObject> coins = new List<GameObject>();
    List<GameObject> powerUp = new List<GameObject>();
    Vector3 PositionPlayer;

    [SerializeField] private float zForcePlayer;
    [SerializeField] private float jumpForcePlayer;
    [SerializeField] private GameObject wall;

    [SerializeField] private GameObject end;

    private bool tutorialIsActive;

    [SerializeField] private float distanceToEnd;

    void Start()
    {
        TutorialStep = new string[] { "Welcome this is the tutorial", "Press W,A,S,D key for MOVEMENT and press down arrow key to CRUNCH", "The bar indicate the remaining path to finish the level.","Press SPACE for JUMP", 
                                    "Collect the Marscoins to buy the skins in the shop!","The collected Marscoins will be shown on the top left","Pick the Marscoin to continue",
                                    "There are three types of PowerUps","When the PowerUp is it picked will be visible on the top right",
                                    "The *MAGNET* will attract coins close to you", "Pick the MAGNET to continue.",
                                    "The *RESIZESCALE* will make you smaller and faster!","Pick the RESIZESCALE to continue.","And the *UPWEIGHT* will make you heavy","Pick the UPWEIGHT.",
                                    "The time remaining to complete the level is shown on the left","Finish the level before time runs out, otherwise GAME OVER.","Climb the leaderboard by getting the best score","An advice.. don't fall from the platform","Good Luck!" };


        DialogProgressBar = new string[] { "What's up bro?", "I'll keep you company in the game!!",
            "lol but i think.. ","i've made a mistake..", "this is not my game", "good luck bro" };


        IntroLevel.SetActive(true);

        TextTutorial = IntroLevel.transform.Find("Tutorial").gameObject;
        TutorialStepText = TextTutorial.GetComponent<Text>();

        ProgressLevel = GameObject.Find("ProgressLevel").gameObject;
        
        DialogProgressText = ProgressLevel.gameObject.transform.Find("Handle Slide Area/Handle/Dialog").gameObject.GetComponent<Text>();

        Handle = ProgressLevel.gameObject.transform.Find("Handle Slide Area/Handle").gameObject;
        Handle.SetActive(false);

        distanceToEnd = ProgressLevel.GetComponent<ProgressLevel>().DistanceFinal;
        ProgressLevel.SetActive(false);

        TargetPlayer = GameObject.Find("Player");
        ObjectPooler = GameObject.Find("ObjectPooler");

        MarsCoin = GameObject.Find("Canvas/MarsCoin");
        MarsCoin.SetActive(false);


        PowerUps = GameObject.Find("Canvas/PowerUps");
        PowerUps.SetActive(false);


        TimeToFinish = GameObject.Find("Canvas/TimeToFinish");
        TimeToFinish.SetActive(false);

        Score = GameObject.Find("Canvas/Score");
        Score.SetActive(false);

        PositionPlayer = TargetPlayer.transform.position;

        zForcePlayer = TargetPlayer.GetComponent<PlayerMovement>().ZForce;
        jumpForcePlayer = TargetPlayer.GetComponent<PlayerMovement>().JumpForce;

        tutorialIsActive = true;

        for (int i = 0; i < 3; i++)
        {
            coins.Add(ObjectPooler.GetComponent<ObjectPooler>().getPooledObject("Marscoin").gameObject);
        }

        powerUp.Add(ObjectPooler.GetComponent<ObjectPooler>().getPooledObject("Magnet").gameObject);
        powerUp.Add(ObjectPooler.GetComponent<ObjectPooler>().getPooledObject("ResizeScale").gameObject);
        powerUp.Add(ObjectPooler.GetComponent<ObjectPooler>().getPooledObject("UpWeight").gameObject);

        wall = ObjectPooler.GetComponent<ObjectPooler>().getPooledObject("Wall").gameObject;

        end = GameObject.Find("End");

        
        end.transform.Spawn(new Vector3(PositionPlayer.x, PositionPlayer.y, PositionPlayer.z + distanceToEnd));

        StartCoroutine(IntroTutorial());
    }

    private void Update()
    {
        moveEnd();  
    }

    IEnumerator IntroTutorial()
    {
     
        // Hi..
        TutorialStepText.text = TutorialStep[0];
        yield return new WaitForSeconds(5f);

        
        // For the mov..
        TutorialStepText.text = TutorialStep[1];  
        yield return new WaitForSeconds(5f);
        yield return new WaitWhile(() => verifyMovePlayer() == false || verifyCrounchedPlayer() == false);


        // The bar..
        TutorialStepText.text = TutorialStep[2];
        ProgressLevel.SetActive(true);
        yield return new WaitForSeconds(5f);
        TutorialStepText.text = "";

        // The rock dialog..
        Handle.SetActive(true);
        foreach(string dialog in DialogProgressBar)
        {
            DialogProgressText.text = dialog;
            yield return new WaitForSeconds(3f);
        }
        DialogProgressText.text = "";
        Handle.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/SplashScreen/Fugopugo1") ;

        // Decrement progressLevel (1/4)
        distanceToEnd = distanceToEnd - 25;
        ProgressLevel.GetComponent<ProgressLevel>().IncrementProgressLevel(distanceToEnd);
        

        // For jump..
        TutorialStepText.text = TutorialStep[3];
        verifyJumpPlayer();
        yield return new WaitForSeconds(5f);
        yield return new WaitWhile(() => verifyJumpPlayer() == false);


        // Use this variable for the spawn..
        int i = 50;

        // Collect the coins..
        TutorialStepText.text = TutorialStep[4];
        SpawnPositionBehindPlayer = new Vector3(0,  1, TargetPlayer.transform.position.z + i);
        coins[0].transform.Spawn(SpawnPositionBehindPlayer);
        SpawnPositionBehindPlayer = new Vector3(0, 7f, TargetPlayer.transform.position.z + i + 5);
        wall.transform.Spawn(SpawnPositionBehindPlayer);
        wall.SetActive(true);
        yield return new WaitForSeconds(8f);

        // You can view..
        TutorialStepText.text = TutorialStep[5];
        yield return new WaitForSeconds(4f);
        MarsCoin.SetActive(true);
        yield return new WaitForSeconds(3f);

        // Collect the coin for continue..
        if (coins[0].gameObject.activeSelf)
        {
            TutorialStepText.text = TutorialStep[6];
        }

        yield return new WaitWhile(() => coins[0].gameObject.activeSelf);
        wall.SetActive(false);

        // Decrement progressLevel (2/4)
        distanceToEnd = distanceToEnd - 25;
        ProgressLevel.GetComponent<ProgressLevel>().IncrementProgressLevel(distanceToEnd);
        

        // Thre are three..
        TutorialStepText.text = TutorialStep[7];  
        yield return new WaitForSeconds(5f);

        // When powerup..
        TutorialStepText.text = TutorialStep[8];
        PowerUps.SetActive(true);
        yield return new WaitForSeconds(5f);

        // Magnet
        TutorialStepText.text = TutorialStep[9];
        SpawnPositionBehindPlayer = new Vector3(0, 0.7f, TargetPlayer.transform.position.z + i);
        powerUp[0].transform.Spawn(SpawnPositionBehindPlayer);
        SpawnPositionBehindPlayer = new Vector3(0, 7f, TargetPlayer.transform.position.z + i + 5);
        wall.transform.Spawn(SpawnPositionBehindPlayer);
        wall.SetActive(true);
        yield return new WaitForSeconds(8f);

        // Collect the magnet for continue.. 
        if(powerUp[0].gameObject != null)
        {
            TutorialStepText.text = TutorialStep[10];
        }

        yield return new WaitWhile(() => powerUp[0].gameObject != null);
        wall.SetActive(false);

        // ResizeScale
        TutorialStepText.text = TutorialStep[11];
        SpawnPositionBehindPlayer = new Vector3(0, 1.5f, TargetPlayer.transform.position.z + i);
        powerUp[1].transform.Spawn(SpawnPositionBehindPlayer);
        SpawnPositionBehindPlayer = new Vector3(0, 1.5f, TargetPlayer.transform.position.z + i + 5);
        wall.transform.Spawn(SpawnPositionBehindPlayer);
        wall.SetActive(true);
        yield return new WaitForSeconds(8f);

        // Collect the ResizeScale for continue..
        if (powerUp[1].gameObject != null)
        {
            TutorialStepText.text = TutorialStep[12];
        }

        yield return new WaitWhile(() => powerUp[1].gameObject != null);
        wall.SetActive(false);

        // UpWeight
        TutorialStepText.text = TutorialStep[13];
        SpawnPositionBehindPlayer = new Vector3(0, 1.5f, TargetPlayer.transform.position.z + i);
        powerUp[2].transform.Spawn(SpawnPositionBehindPlayer);
        SpawnPositionBehindPlayer = new Vector3(0, 1.5f, TargetPlayer.transform.position.z + i + 5);
        wall.transform.Spawn(SpawnPositionBehindPlayer);
        wall.SetActive(true);
        yield return new WaitForSeconds(8f);

        // Collect the UpWeight for continue..
        if (powerUp[2].gameObject != null)
        {
            TutorialStepText.text = TutorialStep[14];
        }

        yield return new WaitWhile(() => powerUp[2].gameObject != null);
        wall.SetActive(false);

        // Decrement progressLevel (3/4)
        distanceToEnd = distanceToEnd - 25;
        ProgressLevel.GetComponent<ProgressLevel>().IncrementProgressLevel(distanceToEnd);
        

        // Over the bar
        TutorialStepText.text = TutorialStep[15];
        TimeToFinish.SetActive(true);
        yield return new WaitForSeconds(5f);

        // If the time..
        TutorialStepText.text = TutorialStep[16];
        yield return new WaitForSeconds(5f);

        // Over you can view score..
        TutorialStepText.text = TutorialStep[17];
        Score.SetActive(true);
        yield return new WaitForSeconds(5f);

        // An advice..
        TutorialStepText.text = TutorialStep[18];
        yield return new WaitForSeconds(5f);

        // Decrement progressLevel (4/4)
        distanceToEnd = distanceToEnd - 24;
        ProgressLevel.GetComponent<ProgressLevel>().IncrementProgressLevel(distanceToEnd);
        tutorialIsActive = false;

        // Good luck
        TutorialStepText.text = TutorialStep[19];
        yield return new WaitForSeconds(5f);

    }


    bool verifyJumpPlayer()
    {
        if (PositionPlayer.y != TargetPlayer.transform.position.y)
        {
          return  true;
        }

        return false;
    }

    bool verifyMovePlayer()
    {
        if (PositionPlayer.x != TargetPlayer.transform.position.x || PositionPlayer.z != TargetPlayer.transform.position.z)
        {
            return true;
        }

        return false;
    }

    bool verifyCrounchedPlayer()
    {
        if(PositionPlayer.y > TargetPlayer.transform.position.y)
        {
            return true;
        }

        return false;
    }

    void moveEnd()
    {
        if (tutorialIsActive)
        {
            end.transform.position = TargetPlayer.transform.position + new Vector3(0, 0, distanceToEnd);
        }
    }

}
