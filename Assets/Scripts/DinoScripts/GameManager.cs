using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float startGameSpeed = 1f;
    [SerializeField] private float stepOfSpeedUpdate = 0.1f;
    [SerializeField] private float startTimer = 1;
    [SerializeField] private float startTimerOfGame = 60;
    private float timer;
    private float timerOfGame;
    public float gameSpeed { get; private set; }
    public int score { get; private set; } = 0;
    public static GameManager gameManager;
    
    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }
    }
    void Start()
    {
        gameSpeed = startGameSpeed;
        timer = startTimer;
        timerOfGame = startTimerOfGame;
    }

    void Update()
    {
        gameSpeed += stepOfSpeedUpdate * Time.deltaTime;
        if (timer <= 0)
        {
            score++;
            timer = startTimer;
        }
        timer -= Time.deltaTime;
        
        if (timerOfGame <= 0 || Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.SetInt("scoreDino", score);
            SceneManager.LoadScene("CatchingLevel");
        }
        timerOfGame -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
