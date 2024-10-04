using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObstacle : MonoBehaviour
{
    [SerializeField] private Vector2 startPosition = new Vector2(10f, -3.6f);
    private float speed;
    void Start()
    {
        transform.position = startPosition;
    }
    void Update()
    {
        UpdateSpeed(GameManager.gameManager.gameSpeed);
        transform.position -= transform.right * speed * Time.deltaTime;
    }
    
    public void UpdateSpeed(float speed) => this.speed = speed;
}
