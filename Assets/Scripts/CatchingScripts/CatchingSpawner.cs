using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectPrefab;
    [SerializeField] private float startTimeToSpawn = 3.0f;
    
    private float currentTimeToSpawn;
    void Start()
    {
        currentTimeToSpawn = startTimeToSpawn;
    }
    void Update()
    {
        if (currentTimeToSpawn <= 0)
        {
            var currentObject = Instantiate
                (_objectPrefab[UnityEngine.Random.Range(0, _objectPrefab.Length)]);
            
            currentTimeToSpawn = startTimeToSpawn;
        }
        currentTimeToSpawn -= Time.deltaTime;
        
    }
}
