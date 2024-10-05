using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainTitle : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    private string nameText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void OnEndEdit(string name)
    {
        nameText = inputField.text;
    }
    public void OnBottomClick()
    {
        PlayerPrefs.SetString("PlayerName", nameText);
        SceneManager.LoadScene("DinoLevel");
    }
}
