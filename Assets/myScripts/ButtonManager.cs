using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic; 
using TMPro;
using System.Collections;

public class ButtonManager : MonoBehaviour
{
// TEXT
	public GameObject Auswahl;
	private TextMeshPro text;
	private string strNumber;
	private string strSign; 

// UI
	public GameObject Buttons_Numbers; 
	public GameObject Buttons_InGame;
	public GameObject Buttons_Introduction;
	public GameObject Buttons_Comparision;

	private GameObject[] m_ArrButtons; 

// BUTTONS
	public GameObject Button_Abfrage;
	public float m_minimal_Playtime = 2.0f; 

	// START
	void Start()
	{
	// Buttonarray
		m_ArrButtons = new GameObject[] { Buttons_Comparision, Buttons_InGame, Buttons_Introduction, Buttons_Numbers }; 

    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Button_OnTaskChangedHandler;

	// Text
		text = Auswahl.GetComponent<TextMeshPro>();
		strSign = "+";

	// Visibility
		deactivateExept(Buttons_Introduction); 
	}


// EVENTHANDLING
	private void Button_OnTaskChangedHandler(gameState newState)
    {
		if(newState == gameState.taskRunning)
        {
			deactivateExept(Buttons_InGame);
			Button_Abfrage.SetActive(false);
			Invoke("activateAbfrageButton", m_minimal_Playtime); 
		}

		if (newState == gameState.taskSwitching)
		{
			deactivateExept(null); 
		}       

		if (newState == gameState.comparision)
		{
			deactivateExept(Buttons_Numbers); 
		}
		if (newState == gameState.solution)
		{
			deactivateExept(Buttons_Comparision);
		}
	}

	private void activateAbfrageButton()
    {
		Button_Abfrage.SetActive(true); 
    }

	public void saveChoice(GameObject obj)
    {
		if(obj.tag == "UINumber")
        {
			strNumber = obj.GetComponentInChildren<TextMeshPro>().text.ToString(); 

		}
		else if (obj.tag == "UISign")
		{
			strSign = obj.GetComponentInChildren<TextMeshPro>().text.ToString();

		}

		text.text = strSign + " " + strNumber;
    }

	private void deactivateExept(GameObject activeObj)
	{
		foreach (GameObject obj in m_ArrButtons)
		{
			obj.SetActive(false);
		}

		if (activeObj)
		{
			activeObj.SetActive(true);
		}
	}

}
