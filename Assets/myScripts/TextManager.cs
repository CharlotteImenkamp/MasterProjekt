using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private GameObject[] m_ArrTextObjects;
    private GameObject[] m_ArrImageObjects;
    private int m_textIndex;

// START
    void Start()
    {
    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += ImageText_OnTaskChangedHandler;
  
    // FIND OBJECTS
        m_ArrTextObjects = GameObject.FindGameObjectsWithTag("UIText");
        m_ArrImageObjects = GameObject.FindGameObjectsWithTag("UIImage");

    // DEFAULT VALUES
        m_textIndex = 0;
        activateNextTextElement();
        deactivateExept(m_ArrImageObjects, null); 
    }

// EVENTHANDLING
    private void ImageText_OnTaskChangedHandler(gameState newState)
    { 
        if(newState == gameState.taskRunning)
        {
            deactivateExept(m_ArrTextObjects, null); 
            if(GameManager.Instance.m_TaskIndex < m_ArrImageObjects.Length)
            {
                deactivateExept(m_ArrImageObjects, m_ArrImageObjects[GameManager.Instance.m_TaskIndex]); 
            }
            else
            {
                deactivateExept(m_ArrImageObjects, null); 
                Debug.Log("TextManager::gameStateHandler >> No more Images to show.");
            }
        }
    }

// NEXT ELEMENT
    public void activateNextTextElement()
    {
        if(GameManager.Instance.state == gameState.introduction)
        {
            if (m_textIndex < m_ArrTextObjects.Length && m_textIndex > -1)
            {
                deactivateExept(m_ArrTextObjects, m_ArrTextObjects[m_textIndex]); 
                m_textIndex++;
            }
            else if(m_textIndex >= m_ArrTextObjects.Length)
            {
                m_textIndex = m_ArrTextObjects.Length - 1;
                deactivateExept(m_ArrTextObjects, m_ArrTextObjects[m_textIndex]);
            }
            else if(m_textIndex <= -1)
            {
                m_textIndex = 0;
                deactivateExept(m_ArrTextObjects, m_ArrTextObjects[m_textIndex]);
            }
            else
            {
                Debug.LogError("TextManager:: activateNextTextElement");
            }
        } 
    }

    public void activatePreviousTextElement()
    {
        if (GameManager.Instance.state == gameState.introduction)
        {
            if (m_textIndex < m_ArrTextObjects.Length && m_textIndex >= 1)
            {
                m_textIndex--;
                deactivateExept(m_ArrTextObjects, m_ArrTextObjects[m_textIndex]);
            }
            else if(m_textIndex >= m_ArrTextObjects.Length)
            {
                m_textIndex = m_ArrTextObjects.Length - 1;
                deactivateExept(m_ArrTextObjects, m_ArrTextObjects[m_textIndex]);
            }
            else if(m_textIndex == 0)
            {
                deactivateExept(m_ArrTextObjects, m_ArrTextObjects[m_textIndex]);
            }
            else if(m_textIndex <= -1)
            {
                m_textIndex = 0; 
                deactivateExept(m_ArrTextObjects, m_ArrTextObjects[m_textIndex]);
            }
            else
            {
                Debug.LogError("TextManager:: activatePreviousTextElement");
            }
        }
    }

//  HELPER FKT
    private void deactivateExept(GameObject[] m_Arr,  GameObject activeObj)
    {
        foreach (GameObject obj in m_Arr)
        {
            obj.SetActive(false);
        }

        if (activeObj)
        {
            activeObj.SetActive(true);
        }
    }
}
