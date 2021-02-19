using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction; 

public class OffsetManager : MonoBehaviour
{
	public GameObject Canvas;
	public GameObject m_handmodel;

    public float m_offset = 0.1f;
    RiggedHand riggedHand;
    CapsuleHand capsuleHand;

    private InteractionHand intHand;
    public GameObject interactionManager;
    public Vector3 newPosition; 

	void Start()
    {
        interactionManager.transform.position = newPosition; 

    // CANVAS
        Canvas.SetActive(false);
        m_handmodel.SetActive(true);

        // OFFSET
        if (riggedHand)
        {
            riggedHand = m_handmodel.GetComponentInChildren<RiggedHand>();
            riggedHand.offset = new Vector3(0, 0, m_offset);
        }

        if (capsuleHand)
        {
            capsuleHand = m_handmodel.GetComponentInChildren<CapsuleHand>();
            capsuleHand.offset = new Vector3(0, 0, m_offset);
        }
        
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
            if (riggedHand)
            {
                riggedHand.offset = new Vector3(m_offset * (GameManager.Instance.m_TaskIndex + 1), 0, 0);
            }
            if (capsuleHand)
            {
                capsuleHand.offset = new Vector3(m_offset * (GameManager.Instance.m_TaskIndex + 1), 0, 0);
            }
        }
        else
        {
            Canvas.SetActive(false);
            m_handmodel.SetActive(true);
        }
    }
}
