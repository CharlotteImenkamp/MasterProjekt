using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private List<Transform> m_ArrTransformations;
    private GameObject[] m_ArrGameObjects; 

// START
    void Start()
    {
    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Blocks_OnTaskChangedHandler;

        // GET BLOCKS
        m_ArrGameObjects = GameObject.FindGameObjectsWithTag("Block");

        // GET TRANSFORMATIONS
        m_ArrTransformations = new List<Transform>(); 
        foreach(GameObject obj in m_ArrGameObjects)
        {
            m_ArrTransformations.Add(obj.transform);
        }
    }


// EVENTHANDLING
    private void Blocks_OnTaskChangedHandler(gameState state)
    {
    // TASK RUNNING
        //  

    // TASK SWITCHING
        Reset_Blocks();

    // NO TASK RUNNING

    }

// RESET
    public void Reset_Blocks()
    {
        Debug.Log("BlockManager::Reset_Blocks"); 

        for (int i = 0; i < m_ArrGameObjects.Length; i++)
        {
            m_ArrGameObjects[i].transform.localPosition = m_ArrTransformations[i].localPosition;
            m_ArrGameObjects[i].transform.localRotation = m_ArrTransformations[i].localRotation;
        }
    }

}
