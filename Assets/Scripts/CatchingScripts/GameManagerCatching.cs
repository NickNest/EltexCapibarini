using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerCatching : MonoBehaviour
{
    [SerializeField] private float startGameSpeed = 1f;
    [SerializeField] private float stepOfSpeedUpdate = 0.1f;
    [SerializeField] private float startTimer = 1;
    [SerializeField] private float startTimerOfGame = 60;
    private float timer;
    private float timerOfGame;
    public float gameSpeed { get; private set; }
    public int score { get; private set; } = 0;
    public int hitpoints { get; private set; } = 3;
    public static GameManagerCatching gameManager;
    
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
        ActionManager.Scoring += OnScoring;
        ActionManager.Damaging += OnDamaging;
    }

    void Update()
    {
        gameSpeed += stepOfSpeedUpdate * Time.deltaTime;
        if (timerOfGame <= 0 || Input.GetKeyDown(KeyCode.N))
        {
            PlayerPrefs.SetInt("ScoreCatching", score);
            SceneManager.LoadScene("LeaderTable");
        }
        timerOfGame -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void OnScoring() => score++;
    public void OnDamaging() => hitpoints--;
}
