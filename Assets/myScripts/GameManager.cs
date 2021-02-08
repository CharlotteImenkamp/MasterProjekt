using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Leap;
using Leap.Unity;


public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; set; }
	public AudioSource m_audioSource;
	public bool m_playMusic;
	public Vector3 idxFingerLeftPos;
	public Vector3 idxFingerRightPos;
	public Hand leftHand;
	public Hand rightHand;

	#region Private Members

	private int m_CurrentSzeneIndex;
	private Controller controller;
	private Frame frame;

    #endregion

    // Awake Singelton
    private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else
		{
			Destroy(this.gameObject);
		}
	}

	// Start is called before the first frame update
	void Start()
    {
		m_CurrentSzeneIndex = 1;

		if (m_playMusic)
		{
			m_audioSource.Play();
		}

		// Hand Tracking
		controller = new Controller();
		idxFingerLeftPos = Vector3.one;
		idxFingerRightPos = Vector3.one;
		leftHand = null;
		rightHand = null; 
	}

	//StartButton clicked
	public void LoadSzene()
	{
		if (m_CurrentSzeneIndex < 5)
		{
			//set new map active
			SceneManager.LoadScene(m_CurrentSzeneIndex);
			m_CurrentSzeneIndex++;
		}
        else
        {
			print("GameManager: No more Scenes available"); 
        }
	}

    public void Update()
    {
		bool bSuccess = UpdateHandPosition(); 
		if (bSuccess)
		{
			//UpdateIndexFingerPosition();
		}
    }


	#region Handtracking
	private bool UpdateHandPosition()
	{
		bool bSuccess = false; 

		//leftHand = null;
		//rightHand = null;

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
/////////////////////////////
		
		if(rightHand != null )
        {
			foreach(Finger finger in rightHand.Fingers)
            {
				if(finger.Type == Finger.FingerType.TYPE_INDEX)
                {
					idxFingerRightPos = finger.TipPosition.ToVector3();
					Debug.Log("GameManager::UpdateIndexFingerPosition >> z Position right: " + idxFingerRightPos.ToString());
				}
            }
		}

		if(leftHand != null)
        {
			idxFingerRightPos = rightHand.Finger(1).TipPosition.ToVector3();
			Debug.Log("GameManager::UpdateIndexFingerPosition >> z Position left:" + idxFingerRightPos.z.ToString());
		}



		//////////////////////////////////

		return bSuccess; 
	}

	private void UpdateIndexFingerPosition()
    {
		idxFingerLeftPos = Vector3.zero;
		idxFingerRightPos = Vector3.zero;

		idxFingerLeftPos = leftHand.Finger(1).TipPosition.ToVector3();
		idxFingerRightPos = rightHand.Finger(1).TipPosition.ToVector3();

		Debug.Log("GameManager::UpdateIndexFingerPosition >> z Position right:"+ idxFingerRightPos.z.ToString());


		if (idxFingerLeftPos== Vector3.zero || idxFingerRightPos == Vector3.zero)
        {
			Debug.Log("GameManager::UpdateIndexFingerPosition >> Fingers not located correct");
		}
	}

	#endregion
}
