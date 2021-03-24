using UnityEngine;
using System.Collections; 
using TMPro;



public class OffsetManager : MonoBehaviour
{
// CANVAS
	public GameObject Canvas;
    private TextMeshPro _textCountDown; 
	private GameObject _handmodel;

// OFFSET
    private float _offset;
    public float offset
    {
        get { return _offset; }
        set
        {
            _offset = value;
            OnOffsetChanged(_offset);
        }
    }
    public delegate void OnOffsetChangedDelegate(float newOffset);
    public event OnOffsetChangedDelegate OnOffsetChanged;

 // HANDS
    public GameObject handModelright;
    public GameObject handModelleft;
    private CustomRiggedHand _handRight;
    private CustomRiggedHand _handLeft;

    private GameObject _solutionSphere; 

    void Start()
    {
        OnOffsetChanged += OnOffsetChangedHandler; 


    // CANVAS
        Canvas.SetActive(false);
        _handmodel = GameObject.Find("Hand Models"); 
        _handmodel.SetActive(true);
        _textCountDown = Canvas.GetComponentInChildren<TextMeshPro>(); 

    // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Canvas_OnTaskChangedHandler;

     // DEFAULT
        _offset = 0.0f;

        // rigged hand
        _handRight = handModelright.GetComponent<CustomRiggedHand>();
        _handLeft  = handModelleft.GetComponent<CustomRiggedHand>();

        // move both models to the right
        _handRight._riggedHandOffset = new Vector3(0, 0, _offset);
        _handLeft._riggedHandOffset = new Vector3(0, 0, _offset);

        // hand copy 
        _solutionSphere = GameObject.Find("PalmPosition");
        _solutionSphere.SetActive(false); 
    }

    private void OnOffsetChangedHandler(float newOffset)
    {
        Debug.Log("Offset changed to " + _offset.ToString());

        // rigged hand 
        _handRight._riggedHandOffset = new Vector3(0, 0, newOffset);
        _handLeft._riggedHandOffset = new Vector3(0, 0, newOffset);
    }


    // EVENTHANDLING
    private void Canvas_OnTaskChangedHandler(gameState newState)
    {
        if(newState == gameState.taskSwitching)
        {
            Canvas.SetActive(true);
            StartCoroutine(ActivateCountDown("3...", 0.1f));
            StartCoroutine(ActivateCountDown("2...", 1.0f));
            StartCoroutine(ActivateCountDown("1...", 2.0f));
            _handmodel.SetActive(false);
            offset += GameManager.Instance.offsetStepsize;

            _solutionSphere.SetActive(false);

        }
        else if(newState == gameState.solution)
        {
            if (_handRight)
            {
                _solutionSphere.transform.position = _handRight.GetPalmPosition() - _handRight._riggedHandOffset;
                _solutionSphere.SetActive(true);
            }
            else if (_handLeft)
            {
                _solutionSphere.transform.position = _handLeft.GetPalmPosition() - _handLeft._riggedHandOffset;
                _solutionSphere.SetActive(true);
            }
            else
            {
                Debug.LogError("Offsetmanager::OnTaskchangedHandler no valid hand found"); 
            }
        }
        else
        {
            Canvas.SetActive(false);
            _handmodel.SetActive(true);

            _solutionSphere.SetActive(false);
        }
    }

    private IEnumerator ActivateCountDown(string str, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        _textCountDown.text = str;
    }

}
