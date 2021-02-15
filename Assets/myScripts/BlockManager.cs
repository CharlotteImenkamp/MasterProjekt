using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private List<Vector3> m_ArrPositions;
    private List<Quaternion> m_ArrRotations; 
    private GameObject[] m_ArrGameObjects;


// START
    void Start()
    {
    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Blocks_OnTaskChangedHandler;

        // GET BLOCKS
        m_ArrGameObjects = GameObject.FindGameObjectsWithTag("Block");

        // GET TRANSFORMATIONS
        m_ArrPositions = new List<Vector3>();
        m_ArrRotations = new List<Quaternion>();
        foreach (GameObject obj in m_ArrGameObjects)
        {
            m_ArrPositions.Add(obj.transform.position);
            m_ArrRotations.Add(obj.transform.rotation); 
        }
    }

    // EVENTHANDLING
    private void Blocks_OnTaskChangedHandler(gameState newState)
    {
        if (newState == gameState.comparision)
        {
        }
        else
        {
            Reset_Blocks();
        }
    }


// RESET
    public void Reset_Blocks()
    {
        Debug.Log("BlockManager::Reset_Blocks"); 

        for (int i = 0; i < m_ArrGameObjects.Length; i++)
        {
            m_ArrGameObjects[i].transform.position = m_ArrPositions[i];
            m_ArrGameObjects[i].transform.rotation = m_ArrRotations[i]; 
            // m_ArrGameObjects[i].transform.position = m_ArrTransformations[i].position;
            // m_ArrGameObjects[i].transform.localRotation = m_ArrTransformations[i].localRotation;
        }
    }

}
