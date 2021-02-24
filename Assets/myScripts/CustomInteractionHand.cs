using UnityEngine;
using Leap;
using Leap.Unity; 
using Leap.Unity.Interaction;

public class CustomInteractionHand: MonoBehaviour
{
    private InteractionHand _intManager;

    private Hand _hand;
    private Hand _handCopy;

    public bool customHandIsRight;

    private Vector3 _newPosition;
    private Quaternion _newRotation;  

    private OffsetManager _offManager;
    public Vector3 _PhysicsHandOffset;

    public CustomRiggedHand handLeft;
    public CustomRiggedHand handRight;



    private void Awake()
    {
        // physics hand 
        _hand = new Hand();
        _handCopy = new Hand();

        _intManager = gameObject.GetComponent<InteractionHand>();
        _intManager.handAccessorFunc = (frame) => TransformLeapHandModel(frame);
    }

    void Start()
    {
        _offManager = GameObject.Find("OffsetManager").GetComponent<OffsetManager>();
        _offManager.OnOffsetChanged += OnOffsetChangedHandler;


        // DEFAULT
        _PhysicsHandOffset = new Vector3(0, 0, _offManager.offset);
    }

    private void OnOffsetChangedHandler(float newOffset)
    {
        _PhysicsHandOffset = new Vector3(0,0, _offManager.offset);

    // physics hand
        _intManager.handAccessorFunc = (frame) => TransformLeapHandModel(frame);        //****  muss ich das hier nochmal machen?
    }

    Hand TransformLeapHandModel(Frame frame)
    {

        if (customHandIsRight)
        {
            _hand = frame.Get(Chirality.Right);
            _handCopy = _hand;
            if (_handCopy != null)
            {
                _newPosition = _handCopy.PalmPosition.ToVector3() + _PhysicsHandOffset;
                
                _newRotation = _handCopy.Rotation.ToQuaternion();
                _handCopy.SetTransform(_newPosition, _newRotation);
            }
        }
        else
        {
            _hand = frame.Get(Chirality.Left);
            _handCopy = _hand;
            if (_handCopy != null)
            {
                _newPosition = _handCopy.PalmPosition.ToVector3() - _PhysicsHandOffset;
                _newRotation = _handCopy.Rotation.ToQuaternion();
                _handCopy.SetTransform(_newPosition, _newRotation);
            }
        }
        return _handCopy;
    }

}
