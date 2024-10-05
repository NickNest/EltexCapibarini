using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingBox : MonoBehaviour
{
    void Start()
    {
        ActionManager.TouchingFallingObject += OnTouchingFallingObject;
    }
    public static void OnTouchingFallingObject(string tag)
    {
        Debug.Log("OnTouchingFallingObject: " + tag);
        if (tag == "WiFi")
        {
            ActionManager.OnScoring();
        }

        if (tag == "BadSignal")
        {
            ActionManager.OnDamaging();
        }
    }
}
