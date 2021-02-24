using UnityEngine;
using TMPro;


public class ButtonManager : MonoBehaviour
{
// TEXT
	public GameObject Auswahl;
	public GameObject EndResult; 

	private TextMeshPro _text;
	private TextMeshPro _endText;
	private string _endNumber; 
	private string _strNumber;
	private string _strSign; 

// UI
	public GameObject Buttons_Numbers; 
	public GameObject Buttons_InGame;
	public GameObject Buttons_Introduction;
	public GameObject Buttons_Comparision;
	public GameObject Buttons_End;

	public GameObject[] CalibrationElements; 

	private GameObject[] _ArrButtons; 

// BUTTONS
	public GameObject Button_Abfrage;

	// START
	void Start()
	{
	// Buttonarray
		_ArrButtons = new GameObject[] { Buttons_Comparision, Buttons_InGame, Buttons_Introduction, Buttons_Numbers, Buttons_End }; 

    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Button_OnTaskChangedHandler;

		// Text
		_endText = EndResult.GetComponent<TextMeshPro>(); 
		_text = Auswahl.GetComponent<TextMeshPro>();
		_strSign = "+";

	// Visibility
		deactivateExept(Buttons_Introduction); 

	// CALIBRATION
		foreach(GameObject obj in CalibrationElements)
        {
			obj.SetActive(false);
        }
	}


// EVENTHANDLING
	private void Button_OnTaskChangedHandler(gameState newState)
    {
		if(newState == gameState.taskRunning)
        {
			deactivateExept(Buttons_InGame);
			Button_Abfrage.SetActive(false);
			Invoke("activateAbfrageButton", GameManager.Instance.minimalPlaytime); 
		}

		if (newState == gameState.taskSwitching)
		{
			deactivateExept(Buttons_InGame); 
		}       

		if (newState == gameState.comparision)
		{
			deactivateExept(Buttons_Numbers);

		// CALIBRATION
			foreach (GameObject obj in CalibrationElements)
			{
				obj.SetActive(false);
			}
		}

		if (newState == gameState.solution)
		{
			deactivateExept(Buttons_Comparision);
		}

		if(newState == gameState.end)
        {
			deactivateExept(Buttons_End); 
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
			_strNumber = obj.GetComponentInChildren<TextMeshPro>().text.ToString(); 

		}
		else if (obj.tag == "UISign")
		{
			_strSign = obj.GetComponentInChildren<TextMeshPro>().text.ToString();

		}

		_text.text = _strSign + " " + _strNumber;
    }

	public void saveEndResult(GameObject obj)
    {
		_endNumber = obj.GetComponentInChildren<TextMeshPro>().text.ToString();
		switch (_endNumber)
        {
			case "1":
				_endText.text = "sehr stark"; 
				break;
			case "2":
				_endText.text = "stark";
				break;
			case "3":
				_endText.text = "neutral";
				break;
			case "4":
				_endText.text = "schwach";
				break;
			case "5":
				_endText.text = "sehr schwach";
				break;
			default:
				Debug.Log("Error in ButtonManager::saveEndResult");
				break; 
		} 
			
	}

	private void deactivateExept(GameObject activeObj)
	{
		foreach (GameObject obj in _ArrButtons)
		{
			obj.SetActive(false);
		}

		if (activeObj)
		{
			activeObj.SetActive(true);
		}
	}
}
