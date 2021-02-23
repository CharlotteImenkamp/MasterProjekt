using UnityEngine;
using Leap.Unity;
using Leap; 



public class OffsetManager : MonoBehaviour
{
	public GameObject Canvas;
	public GameObject _handmodel;

    public float _offset;
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

    // rigged hand 
    public GameObject handModelright;
    public GameObject handModelleft;
    private RiggedHand _handRight;
    private RiggedHand _handLeft;

    private GameObject _solutionSphere; 
    private Hand _handCopyRight;
    private Hand _handCopyLeft;

    void Start()
    {
        OnOffsetChanged += OnOffsetChangedHandler; 


    // CANVAS
        Canvas.SetActive(false);
        _handmodel.SetActive(true);

     // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Canvas_OnTaskChangedHandler;

     // DEFAULT
        _offset = 0.0f;

        // rigged hand
        _handRight = handModelright.GetComponent<RiggedHand>();
        _handLeft  = handModelleft.GetComponent<RiggedHand>();

        _handRight._riggedHandOffset = new Vector3(0, 0, _offset);
        _handLeft._riggedHandOffset = new Vector3(0, 0, - _offset);

        // hand copy 
        _handCopyRight = new Hand();
        _handCopyLeft  = new Hand();
        _solutionSphere = GameObject.Find("SolutionSphere");
        _solutionSphere.SetActive(false); 
    }

    private void OnOffsetChangedHandler(float newOffset)
    {
        Debug.Log("Offset changed to " + _offset.ToString());

        // rigged hand 
        _handRight._riggedHandOffset = new Vector3(0, 0, newOffset);
        _handLeft._riggedHandOffset = new Vector3(0, 0, -newOffset);
    }


    // EVENTHANDLING
    private void Canvas_OnTaskChangedHandler(gameState newState)
    {
        if(newState == gameState.taskSwitching)
        {
            Canvas.SetActive(true);
            _handmodel.SetActive(false);
            offset += 0.1f;

            _solutionSphere.SetActive(false);

        }
        else if(newState == gameState.solution)
        {
            _solutionSphere.transform.position = _handRight.GetPalmPosition();
            _solutionSphere.SetActive(true); 
        }
        else
        {
            Canvas.SetActive(false);
            _handmodel.SetActive(true);

            _solutionSphere.SetActive(false);

        }
    }
}
