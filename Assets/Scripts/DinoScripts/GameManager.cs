using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float startGameSpeed = 1f;
    [SerializeField] private float stepOfSpeedUpdate = 0.1f;
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
        ActionManager.Scoring += OnScoring;
    }
    
    void Update()
    {
            gameSpeed += stepOfSpeedUpdate * Time.deltaTime;
    }
    
    public void OnScoring()
    {
        score++;
    }
}
