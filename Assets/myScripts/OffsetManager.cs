using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class OffsetManager : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject m_handmodel;
	public float offset = 5.0f;

	// HANDTRACKING
	public Hand leftHand;
	public Hand rightHand;

	private Controller controller;
	private Frame frame;
	private List<Hand> hands; 

	void Start()
    {
    // CANVAS
        Canvas.SetActive(false);
        m_handmodel.SetActive(true); 
        
    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Canvas_OnTaskChangedHandler;

	// HANDTRACKING
		controller = new Controller();
		leftHand = null;
		rightHand = null;
	}

// UPDATE	
    private void Update()
    {
		frame = controller.Frame();
		hands = frame.Hands;
		UpdateHandPosition();
		if (rightHand != null)
		{
			Vector3 newPosition = rightHand.PalmPosition.ToVector3() + Vector3.right * offset;
			Quaternion newRotation = rightHand.Rotation.ToQuaternion();
			rightHand.SetTransform(newPosition, newRotation);
		}
		if (leftHand != null)
		{
			Vector3 newPosition = leftHand.PalmPosition.ToVector3() + Vector3.right * offset;
			Quaternion newRotation = leftHand.Rotation.ToQuaternion();
			leftHand.SetTransform(newPosition, newRotation);
		}
		//Debug.Log("Right Hand" + rightHand.GetPinchPosition().ToString()); 
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

// HANDTRACKING
	private void UpdateHandPosition() // ChangeHandPosition neuer name
	{
		leftHand = null;
		rightHand = null;

		if (hands.Count != 0)
		{
			foreach (Hand hand in hands)
			{
				if (hand.IsLeft)
				{
					leftHand = hand;
					Debug.Log("GameManager::UpdateHandPosition >> Left hand found");
				}
				else if (hand.IsRight)
				{
					rightHand = hand;
					Debug.Log("GameManager::UpdateHandPosition >> Right hand found");
				}
				else
				{
					// Debug.Log("GameManager::UpdateHandPosition >> Error");
				}
			}
		}
		else
		{
			//Debug.Log("GameManager::UpdateHandPosition >> No hand found");
		}
	}
}
