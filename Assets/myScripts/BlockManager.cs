using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject blockGameObject; 

// START
    void Start()
    {
    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Blocks_OnTaskChangedHandler;

    // GET BLOCKS
        
    // GET TRANSFORMATIONS

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
    void Reset_Blocks()
    {
        //\do stuff
    }

}
