using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class OffsetManager : MonoBehaviour
{
	public GameObject Canvas;
	public GameObject m_handmodel;

    public float m_offset = 0.1f;
    RiggedHand riggedHand;
    CapsuleHand capsuleHand; 

	void Start()
    {

    // CANVAS
        Canvas.SetActive(false);
        m_handmodel.SetActive(true);

    // OFFSET
        riggedHand = m_handmodel.GetComponentInChildren<RiggedHand>();
        riggedHand.offset = new Vector3(0, 0, m_offset);

        capsuleHand = m_handmodel.GetComponentInChildren<CapsuleHand>();
        capsuleHand.offset = new Vector3(0, 0, m_offset);

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

            // Set offset 
            riggedHand.offset = new Vector3(m_offset  * (GameManager.Instance.m_TaskIndex+1), 0, 0);
            capsuleHand.offset = new Vector3(m_offset * (GameManager.Instance.m_TaskIndex+1), 0, 0);
        }
        else
        {
            Canvas.SetActive(false);
            m_handmodel.SetActive(true);
        }
    }
}
