using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonHandler : MonoBehaviour
{
	public Button yourButton;

	void Start()
	{
		Button btn = yourButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		GameManager.Instance.LoadSzene();
	}

	// workaround without VR
	void Update()
	{
		if (Input.GetKey("n"))
		{
			GameManager.Instance.LoadSzene();
		}
	}
}
