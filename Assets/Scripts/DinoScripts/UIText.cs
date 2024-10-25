using TMPro;
using UnityEngine;

public class UIText : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    private int _currentScore;

    void Update()
    {
        _currentScore = GameManager.gameManager.score;
        _scoreText.text = _currentScore.ToString();
    }
}
