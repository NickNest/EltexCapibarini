using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndTitleScript : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        titleText.text = $"Поздравляем {PlayerPrefs.GetString("PlayerName")}\n Ваш счет " +
                         $"{PlayerPrefs.GetInt("ScoreCatching") + PlayerPrefs.GetInt("scoreDino")}";
    }
}
