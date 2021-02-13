using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; 
using TMPro;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{

	// TEXT
	private List<Text> m_textArr = null;
	public  List<GameObject> m_textObject;
	// private int m_arrayIndex;
	private bool m_stop;

	// BUTTONS
	private List<Button> buttonsInGame; 


// START
	void Start()
	{
    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Button_OnTaskChangedHandler;

	// FIND BUTTONS
		GameObject[] btn = GameObject.FindGameObjectsWithTag("Button");
		foreach(GameObject obj in btn)
        {
			buttonsInGame.Add(obj.GetComponent<Button>());
        }
		Debug.Log(buttonsInGame.ToString()); 
		 

		// assign buttons
		/* m_StartButton = m_StartButton.gameObject.GetComponent<Button>();
		m_StartButton.onClick.AddListener(() =>
        {}); */

		// assign texts
        foreach(GameObject obj in m_textObject)
        {
			m_textArr.Add(obj.GetComponent<Text>()); 
		}

		// m_arrayIndex = 0;
		// _ManageVisibility();
		
	}

// EVENTHANDLING
	private void Button_OnTaskChangedHandler(gameState newState)
    {
	// TASK RUNNING
		// ButtonHandler Numbers inactive
		// ButtonHandler Game	 active

	// TASK SWITCHING
		// ButtonHandler Numbers inactive
		// ButtonHandler Game	 inactive

	// NO TASK RUNNING
		// ButtonHandler Numbers active 
		// ButtonHandler Game	 inactive

		throw new System.NotImplementedException();
    }

// UPDATE
	void Update()
	{

		// *****Workaround
		if (!m_stop)
		{
			//_ManageVisibility();
		}
	}

	/*
	void _ManageVisibility()
	{
		if (m_arrayIndex < m_textArr.Length)
		{
			//manage visibility
			foreach (TextMeshProUGUI text in m_textArr)
			{
				text.gameObject.SetActive(false);
			}
			m_textArr[m_arrayIndex].gameObject.SetActive(true);
			m_arrayIndex++;
			m_stop = false;
		}
		else
		{
			m_stop = true;
			print("ButtonHandler::ManageVisibility >> No more text to show.");
		}
	}*/
}
