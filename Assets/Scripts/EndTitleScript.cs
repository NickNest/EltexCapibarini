
using TMPro;
using UnityEngine;
using System.Collections;
using System.Linq;
using Firebase.Database;

public class EndTitleScript : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _leadersNames;
    [SerializeField] private TMP_Text[] _leadersScores;

    private int _leadersCount = 5;
    private int _finalScore;
    private string _playerName;
    private DatabaseReference _dbRef;

    private void Start()
    {
        _dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        _finalScore = PlayerPrefs.GetInt("ScoreCatching") + PlayerPrefs.GetInt("scoreDino");
        _playerName = PlayerPrefs.GetString("PlayerName");
        SaveData();
        StartCoroutine(GetAllUsers());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }


    public void SaveData()
    {
        User user = new User(_playerName, _finalScore);
        string json = JsonUtility.ToJson(user);
        _dbRef.Child("LeaderBoard").Child(_playerName).SetRawJsonValueAsync(json);
    }

    public IEnumerator GetAllUsers()
    {
        var users = _dbRef.Child("LeaderBoard").OrderByChild("score").LimitToLast(_leadersCount).GetValueAsync();

        yield return new WaitUntil(() => users.IsCompleted);

        if (users.Exception != null)
        {
            Debug.LogException(users.Exception);
        }
        else if (users.Result == null)
        {
            Debug.Log("Null");
        }
        else
        {
            DataSnapshot snapshot = users.Result;
            int i = 0;
            foreach (var childSnapshot in snapshot.Children.Reverse())
            {
                _leadersNames[i].text = childSnapshot.Child("name").Value.ToString();
                _leadersScores[i].text = childSnapshot.Child("score").Value.ToString();
                Debug.Log(childSnapshot.Child("score").Value.ToString() + " очков у " + childSnapshot.Child("name").Value.ToString());
                i++;
            }
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
