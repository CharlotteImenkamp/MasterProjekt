using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;

public class TestSkript : MonoBehaviour
{


    void Start()
    {
        // GameManager.Instance.state = gameState.taskPausing; 
    }

	/*
    // HANDTRACKING
    public Vector3 idxFingerLeftPos;
    public Vector3 idxFingerRightPos;
    public Hand leftHand;
    public Hand rightHand;
    private Controller controller;
    private Frame frame;

    // HANDTRACKING
    controller = new Controller();
    idxFingerLeftPos = Vector3.one;
		idxFingerRightPos = Vector3.one;
		leftHand = null;
		rightHand = null; 
	}

#region Handtracking
private bool UpdateHandPosition()
{
	bool bSuccess = false;

	leftHand = null;
	rightHand = null;

	frame = controller.Frame();
	var hands = frame.Hands;

	if (hands.Count != 0)
	{
		foreach (Hand hand in hands)
		{
			bSuccess = true;

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
				bSuccess = false;
			}
		}
	}
	else
	{
		//Debug.Log("GameManager::UpdateHandPosition >> No hand found");
	}


	return bSuccess;
}

private bool CheckThumbsup()
{
	Vector3 thumbDir = leftHand.GetThumb().Direction.ToVector3();

	if (Vector3.up == thumbDir)
	{

	}

	return true;
}

private void UpdateIndexFingerPosition()
{

	if (rightHand != null)
	{
		rightHand.GetIndex();
		foreach (Finger finger in rightHand.Fingers)
		{
			if (finger.Type == Finger.FingerType.TYPE_INDEX)
			{
				idxFingerRightPos = finger.TipPosition.ToVector3();
				Debug.Log("GameManager::UpdateIndexFingerPosition >> z Position right: " + idxFingerRightPos.ToString());
			}
		}
	}

	if (leftHand != null)
	{
		foreach (Finger finger in rightHand.Fingers)
		{
			if (finger.Type == Finger.FingerType.TYPE_INDEX)
			{
				idxFingerRightPos = finger.TipPosition.ToVector3();
				Debug.Log("GameManager::UpdateIndexFingerPosition >> z Position right: " + idxFingerRightPos.ToString());
			}
		}
	}
}

#endregion

*/
void Update()
    {

    }

}
