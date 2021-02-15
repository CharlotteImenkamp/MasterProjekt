using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetManager : MonoBehaviour
{
    public GameObject Canvas;
    // public GameObject Hands; 

    void Start()
    {
        Canvas.SetActive(false);
        // Hands.SetActive(true); 

        // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Canvas_OnTaskChangedHandler;

    }

// EVENTHANDLING
    private void Canvas_OnTaskChangedHandler(gameState newState)
    {
        if(newState == gameState.taskSwitching)
        {
            Canvas.SetActive(true);
            // Hands.SetActive(false); 
        }
        else
        {
            Canvas.SetActive(false);
            // Hands.SetActive(true); 
        }
    }
}
