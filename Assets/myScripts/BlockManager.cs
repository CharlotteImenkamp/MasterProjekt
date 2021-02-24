using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    private List<Vector3> _ArrPositions;
    private List<Quaternion> _ArrRotations; 
    private GameObject[] _ArrGameObjects;


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
    }

// EVENTHANDLING
    private void Blocks_OnTaskChangedHandler(gameState newState)
    {
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
