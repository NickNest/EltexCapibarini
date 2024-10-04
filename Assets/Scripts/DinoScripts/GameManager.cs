using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float startGameSpeed = 1f;
    [SerializeField] private float stepOfSpeedUpdate = 0.1f;
    [SerializeField] private float startTimer = 1;
    private float timer;
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
    }
}
