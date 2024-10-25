using TMPro;
using UnityEngine;

public class ScoreTextCatching : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _currentScore;

    void Update()
    {
        _currentScore = GameManagerCatching.gameManager.score;
        _scoreText.text = _currentScore.ToString();
    }
}
