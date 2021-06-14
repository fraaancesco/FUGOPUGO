using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class SoundManager : Singleton<SoundManager>
{
 
    [SerializeField] AudioSource musicSource,CoinSource, playerSource , powerUpSource , finishLevel;
    [SerializeField] AudioClip[] soundTrack;
    [SerializeField] AudioClip[] playerJump , playerObstacle;
    [SerializeField] AudioClip playerCrouch;
    [SerializeField] AudioClip coin , magnet , resizeScale,upWeight;
    [SerializeField] AudioClip levelComplete;
    [SerializeField] AudioSource buttonSource;
    [SerializeField] AudioClip[] clipButton;

    [SerializeField] AudioMixerGroup audioMixer;
    protected override void OnAwake()
    {
        _persistent =  false;
    }

    private void Start()
    {
        SoundTrack(SceneManager.GetActiveScene().buildIndex);
        ButtonSetup();
        PlayerSetup();
        CoinSetup();
        PowerUpSetup();
    }

    private void SoundTrack(int level)
    {
        SoundTrackSetup();

        switch (level)
        {
            case 0:
                musicSource.clip = soundTrack[0];
                break;
            case 1:
                musicSource.clip = soundTrack[1];
                break;
            case 2:
                musicSource.clip = soundTrack[2];
                break;
            case 3:
                musicSource.clip = soundTrack[3];
                break;

            default:
                break;
        }
        musicSource.Play();
    }

    private void SoundTrackSetup()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.volume = 0.2f;
        musicSource.priority = 20;
        musicSource.spatialBlend = 0.5f;
        musicSource.outputAudioMixerGroup = audioMixer;
    }

    private void PlayerSetup()
    {
        playerSource = gameObject.AddComponent<AudioSource>();
        playerSource.loop = false;
        playerSource.volume = 0.4f;
        playerSource.priority = 50;
        playerSource.outputAudioMixerGroup = audioMixer;
    }

    private void CoinSetup()
    {
        CoinSource = gameObject.AddComponent<AudioSource>();
        CoinSource.loop = false;
        CoinSource.volume = 0.4f;
        CoinSource.priority = 50;
        CoinSource.outputAudioMixerGroup = audioMixer;
    }

    private void PowerUpSetup()
    {
        powerUpSource = gameObject.AddComponent<AudioSource>();
        powerUpSource.loop = false;
        powerUpSource.volume = 0.6f;
        powerUpSource.priority = 50;
        powerUpSource.outputAudioMixerGroup = audioMixer;
    }
    
    private void ButtonSetup()
    {
        buttonSource = gameObject.AddComponent<AudioSource>();
        buttonSource.loop = false;
        buttonSource.volume = 0.1f;
        buttonSource.priority = 10;
        buttonSource.outputAudioMixerGroup = audioMixer;
    }

    private void FinishLevelSetup()
    {
        finishLevel = gameObject.AddComponent<AudioSource>();
        finishLevel.loop = false;
        finishLevel.volume = 0.6f;
        finishLevel.priority = 210;
        finishLevel.outputAudioMixerGroup = audioMixer;
    }

    public void ButtonHover()
    {
        buttonSource.clip = clipButton[0];
        buttonSource.Play();
    }

    public void ButtonClick()
    {
        buttonSource.clip = clipButton[1];
        buttonSource.Play();
    }

    public void JumpPlayer()
    {
        playerSource.clip = playerJump[Random.Range(0, playerJump.Length)];
        playerSource.Play();
    }

    public void CrouchPlayer()
    {
        playerSource.clip = playerCrouch;
        playerSource.Play();
    }

    public void ObstaclePlayer(string obstacle)
    {
       
        switch (obstacle)
        {
            case "Rectangle":
                playerSource.clip = playerObstacle[Random.Range(0, playerObstacle.Length)];
                break;

            case "WallHole":

                break;
            default:
                break;
        }
        playerSource.Play();
    }

    public void CoinSound()
    {
        CoinSource.clip = coin;
        CoinSource.Play();
    }

    public void LevelEnd()
    {
        finishLevel.clip = levelComplete;
        finishLevel.Play();
    }

    public void PowerUps(string powerUpName)
    {
        switch (powerUpName)
        {
            case "Magnet":
                powerUpSource.clip = magnet;
                break;
            case "ResizeScale":
                powerUpSource.clip = resizeScale;
                break;
            case "UpWeight":
                powerUpSource.clip = upWeight;
                break;
        }
        powerUpSource.Play();
    }

}