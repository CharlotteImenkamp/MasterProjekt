using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



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

	// MUSIK
	public bool m_playMusic;
	public AudioSource m_audioSource;

	// LEVEL
	public int m_TaskIndex;

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

		// DEFAULT
		m_TaskIndex = 0;
	}

	// EVENTHANDLING
    private void OnTaskChangedHandler(gameState newState)
    {
	
	// TASK SWITCHING
		if(newState == gameState.taskSwitching)
        {
			Invoke("setGameStatetoRunning", 3);  
        }
		if(newState == gameState.taskRunning)
        {

        }
    }

    #region GameStates

    public void setGameStatetoRunning()
    {
		state = gameState.taskRunning;
		m_TaskIndex++; 
	}
	public void setGameStatetoComparision()
	{
		state = gameState.comparision;
	}
	public void setGameStatetoSwitching()
	{
		state = gameState.taskSwitching;
	}
	public void setGameStatetoSolution()
	{
		state = gameState.solution;
	}

	#endregion
}
