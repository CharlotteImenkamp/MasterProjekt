using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
	// public 
	// public Button m_StartButton;
	//  public Button m_OkButton;

	// public TextMeshProUGUI[] m_textGUIArray;
	public float m_displayTime = 3; 

	// private

	private TextMeshProUGUI[] m_textArr = null;
	private int m_arrayIndex;
	private bool m_stop;
	private float m_timer; 

	void Start()
	{
		/* 
		// assign buttons
		m_StartButton = m_StartButton.gameObject.GetComponent<Button>();
		m_OkButton = m_OkButton.gameObject.GetComponent<Button>();

		m_StartButton.onClick.AddListener(() =>
        {
            GameManager.Instance.LoadSzene();
			print("Start Button was pressed");
		});

		m_OkButton.onClick.AddListener(() => 
		{
			_ManageVisibility();
			print("Okay Button was pressed");
		});

		// assign texts
		m_textArr = new TextMeshProUGUI[m_textGUIArray.Length];
        for (int i = 0; i < m_textGUIArray.Length; i++)
        {
			m_textArr.SetValue(m_textGUIArray[i].GetComponent<TextMeshProUGUI>(), i);
		}

		m_arrayIndex = 0;
		_ManageVisibility();
		*/
	}



	// workaround without VR
	void Update()
	{
		m_timer += Time.deltaTime; 
		// Load Szene
		if (Input.GetKey("n"))
		{
			print("Start Key 'n' was pressed"); 
			GameManager.Instance.LoadSzene();
		}

		/*
		if (m_timer >= m_displayTime && !m_stop)
		{
			_ManageVisibility();
			m_timer = 0.0f; 
		}*/
	}


	public void ButtonPressed()
	{
		print("Start Button was pressed");
	}


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
	}
}
