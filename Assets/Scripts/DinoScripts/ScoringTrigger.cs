using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        ActionManager.OnScoring();
    }
}
