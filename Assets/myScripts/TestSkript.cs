using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestSkript : MonoBehaviour
{


    void Start()
    {
        GameManager.Instance.state = gameState.taskPausing; 
    }

    void Update()
    {

    }

}
