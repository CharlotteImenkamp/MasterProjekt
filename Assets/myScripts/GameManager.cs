using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;


public class GameManager : MonoBehaviour
{
// PARAMETERS
    public static GameManager Instance { get; set; }

	// EVENTHANDLING
	private gameState m_state;
	public gameState state{
		get { return m_state; }
		set {
			m_state = value;
			OnTaskChanged(m_state); }
		}
	public delegate void OnTaskChangedDelegate(gameState newState);
	public event OnTaskChangedDelegate OnTaskChanged;

	// TEXT
	public bool m_startText;

	// MUSIK
	public bool m_playMusic;
	public AudioSource m_audioSource;

	// HANDTRACKING
	public Vector3 idxFingerLeftPos;
	public Vector3 idxFingerRightPos;
	public Hand leftHand;
	public Hand rightHand;
	private Controller controller;
	private Frame frame;

    // SINGELTON
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

// START
	void Start()
    {
    // EVENTHANDLING
        OnTaskChanged += OnTaskChangedHandler;

	// MUSIK
		if (m_playMusic)
		{
			m_audioSource.Play();
		}

	// TEXT
		m_startText = false; 

	// HANDTRACKING
		controller = new Controller();
		idxFingerLeftPos = Vector3.one;
		idxFingerRightPos = Vector3.one;
		leftHand = null;
		rightHand = null; 
	}

	// EVENTHANDLING
    private void OnTaskChangedHandler(gameState newState)
    {
		Debug.Log("GameManager::TaskChanged");				// \todo: do stuff

	// TASK RUNNING
		// VibrationManager		active 
	
	// TASK SWITCHING
		// Canvas Manager		active
		// Hand Position wechseln 

	// NO TASK RUNNING

		throw new NotImplementedException();
    }

    // UPDATE
    public void Update()
    {
	// HANDTRACKING
		/*
		bool bSuccess = UpdateHandPosition(); 
		if (bSuccess)
		{
			UpdateIndexFingerPosition();
		}*/

	// TEXT
		m_startText = true; 
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

		if(Vector3.up == thumbDir)
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
}
