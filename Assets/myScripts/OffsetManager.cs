using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetManager : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject m_handmodel;



    void Start()
    {
    // CANVAS
        Canvas.SetActive(false);
        m_handmodel.SetActive(true); 
        
    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Canvas_OnTaskChangedHandler;

    }

// EVENTHANDLING
    private void Canvas_OnTaskChangedHandler(gameState newState)
    {
        if(newState == gameState.taskSwitching)
        {
            Canvas.SetActive(true);
            m_handmodel.SetActive(false); 
        }
        else
        {
            Canvas.SetActive(false);
            m_handmodel.SetActive(true);
        }
    }
}
