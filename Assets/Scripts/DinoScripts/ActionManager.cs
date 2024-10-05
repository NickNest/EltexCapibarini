using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static event Action Scoring;
    public static event Action TouchingObstacle;
    public static event Action<string> TouchingFallingObject;
    public static event Action Damaging;

    public static void OnDamaging()
    {
        Damaging?.Invoke();
    }
    public static void OnTouchingObstacle()
    {
        TouchingObstacle?.Invoke();
    }
    public static void OnScoring()
    {
        Scoring?.Invoke();
    }

    public static void OnTouchingFallingObject(string tag)
    {
        TouchingFallingObject?.Invoke(tag);
    }
}
