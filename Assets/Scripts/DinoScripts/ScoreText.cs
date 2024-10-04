using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    private int currentScore;

    void Start()
    {
    }
    void Update()
    {
        currentScore = GameManager.gameManager.score;
        scoreText.text = currentScore.ToString();
    }
}
