using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
	public Button m_StartButton;
	public Button m_OkButton;
	public Text m_TutorialText; 


	void Start()
	{
		Button btn_start = m_StartButton.GetComponent<Button>();
		Button btn_ok = m_OkButton.GetComponent<Button>();
		m_TutorialText = gameObject.GetComponent<Text>(); 

		btn_start.onClick.AddListener(Click_Start);
		btn_ok.onClick.AddListener(Click_Ok);

		//btn_start.enabled = false; 
	}



	void Click_Ok()
	{
	}

	void Click_Start()
	{
		GameManager.Instance.LoadSzene();
	}

	// workaround without VR
	void Update()
	{
		// Load Szene
		if (Input.GetKey("n"))
		{
			GameManager.Instance.LoadSzene();
		}

		// Ok
		if (Input.GetKey("o"))
		{
			m_TutorialText.Text = "Zweiter Text"; 
		}

	}
}
