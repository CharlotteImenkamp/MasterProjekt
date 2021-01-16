using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; set; }

	public int m_CurrentSzeneIndex; 

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
		m_CurrentSzeneIndex = 0; 
    }

	//StartButton clicked
	public void LoadSzene()
	{
		if (m_CurrentSzeneIndex < 3)
		{
			//set new map active
			SceneManager.LoadScene(m_CurrentSzeneIndex);
		}
        else
        {
			print("GameManager: No more Scenes available"); 
        }
		//go on
		m_CurrentSzeneIndex++;
	}
}
