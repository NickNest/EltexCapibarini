using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObj : MonoBehaviour
{
    private float speed;
    void Start()
    {
        transform.position = new Vector2(UnityEngine.Random.Range(-8, 8), 6);
    }
    void Update()
    {
        UpdateSpeed(GameManagerCatching.gameManager.gameSpeed);
        transform.position -= transform.up * speed * Time.deltaTime;
    }
    
    public void UpdateSpeed(float speed) => this.speed = speed;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        { 
            ActionManager.OnTouchingFallingObject(gameObject.tag);
            Destroy(this.gameObject);
        }
    }
}
