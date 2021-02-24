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


	public int m_TaskIndex;


// General Settings
	[Header("General Settings")]

	// music
	public bool m_playMusic = false;
	public AudioSource m_audioSource;

	// playtime
	public float minimalPlaytime = 2.0f;

	// offset
	public float offsetStepsize = 0.1f; 

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
		m_audioSource.mute = true;


		// MUSIK
		if (m_playMusic)
		{
			m_audioSource.Play();
			m_audioSource.mute = false; 
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
		if(m_TaskIndex < 4)
        {
			state = gameState.taskSwitching;
		}
        else
        {
			setGameStatetoEnd(); 
        }
		
	}
	public void setGameStatetoSolution()
	{
		state = gameState.solution;
	}

	public void setGameStatetoEnd()
	{
		state = gameState.end;
	}

	#endregion
}
