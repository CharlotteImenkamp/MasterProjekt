using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private List<Vector3> _ArrPositions;
    private List<Quaternion> _ArrRotations; 
    private GameObject[] _ArrGameObjects;
    private GameObject[] skalaObjs; 

// START
    void Start()
    {
    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Blocks_OnTaskChangedHandler;

    // GET BLOCKS
        _ArrGameObjects = GameObject.FindGameObjectsWithTag("Block");

    // GET TRANSFORMATIONS
        _ArrPositions = new List<Vector3>();
        _ArrRotations = new List<Quaternion>();
        foreach (GameObject obj in _ArrGameObjects)
        {
            _ArrPositions.Add(obj.transform.position);
            _ArrRotations.Add(obj.transform.rotation); 
        }

        skalaObjs = GameObject.FindGameObjectsWithTag("UISkala"); 

        foreach (GameObject obj in skalaObjs)
        {
            obj.SetActive(true);
        }
    }

// EVENTHANDLING
    private void Blocks_OnTaskChangedHandler(gameState newState)
    {
        // Blocks
        if (newState == gameState.comparision || newState == gameState.solution|| newState == gameState.end)
        {
            foreach(GameObject obj in _ArrGameObjects)
            {
                obj.SetActive(false); 
            }
        }
        else
        {
            foreach (GameObject obj in _ArrGameObjects)
            {
                obj.SetActive(true);
            }
            Reset_Blocks();
        }

        // Skala
        if(newState == gameState.comparision || newState == gameState.solution)
        {
            foreach (GameObject obj in skalaObjs)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject obj in skalaObjs)
            {
                obj.SetActive(true);
            }
        }

    }


// RESET
    public void Reset_Blocks()
    {
        for (int i = 0; i < _ArrGameObjects.Length; i++)
        {
            _ArrGameObjects[i].transform.position = _ArrPositions[i];
            _ArrGameObjects[i].transform.rotation = _ArrRotations[i]; 
        }
    }

}
