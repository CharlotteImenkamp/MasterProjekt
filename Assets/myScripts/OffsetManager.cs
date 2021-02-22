using UnityEngine;


public class OffsetManager : MonoBehaviour
{
	public GameObject Canvas;
	public GameObject m_handmodel;

    private float m_offset;
    public float offset
    {
        get { return m_offset; }
        set
        {
            m_offset = value;
            OnOffsetChanged(m_offset);
        }
    }
    public delegate void OnOffsetChangedDelegate(float newOffset);
    public event OnOffsetChangedDelegate OnOffsetChanged;


	void Start()
    {
        OnOffsetChanged += OnOffsetChangedHandler; 


    // CANVAS
        Canvas.SetActive(false);
        m_handmodel.SetActive(true);

     // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Canvas_OnTaskChangedHandler;

     // DEFAULT
        m_offset = 0; 
	}

    private void OnOffsetChangedHandler(float newOffset)
    {
        Debug.Log("Offset changed to " + m_offset.ToString()); 
    }



    // EVENTHANDLING
    private void Canvas_OnTaskChangedHandler(gameState newState)
    {
        if(newState == gameState.taskSwitching)
        {
            Canvas.SetActive(true);
            m_handmodel.SetActive(false);
            offset += 0.1f;
        }
        else
        {
            Canvas.SetActive(false);
            m_handmodel.SetActive(true);
        }
    }
}
