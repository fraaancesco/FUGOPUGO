using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject introLevel;
    

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            introLevel = GameObject.Find("IntroLevel");
        }

       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;

        if (isPaused)
            ActivateMenu();
        else 
            DeactivateMenu();
    }
    

    void ActivateMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            introLevel.SetActive(false);
        }
        Time.timeScale = 0;
        AudioListener.pause = true;
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            introLevel.SetActive(true);
        }
        Time.timeScale = 1;
        AudioListener.pause = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
        
    }
}
