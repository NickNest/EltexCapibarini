using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    public static event Action Scoring;

    public static void OnScoring()
    {
        Scoring?.Invoke();
    }
}
