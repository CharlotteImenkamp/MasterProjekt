using UnityEngine;
using Leap;
using Leap.Unity; 
using Leap.Unity.Interaction;
using System;

public class CustomHand: MonoBehaviour
{
    private InteractionHand _intManager;

    private Hand hand;
    private Hand handCopy;

    public bool customHandIsRight;

    private Vector3 newPosition;
    private Quaternion newRotation = new Quaternion(0, 0, 0, 0);

    private OffsetManager _offManager;
    public Vector3 _offset;

    public GameObject handModelright;
    public GameObject handModelleft;
    private RiggedHand handRight;
    private RiggedHand handLeft;


    void Start()
    {
        _offManager.OnOffsetChanged += OnOffsetChangedHandler; 

    // rigged hand
        handRight = handModelright.GetComponent<RiggedHand>();
        handLeft = handModelleft.GetComponent<RiggedHand>();

        handRight.offset = _offset;
        handLeft.offset = -_offset;

    // physics hand 
        hand = new Hand();
        handCopy = new Hand();

        _intManager = gameObject.GetComponent<InteractionHand>();
        _intManager.handAccessorFunc = (frame) => TransformLeapHandModel(frame);

    }

    private void OnOffsetChangedHandler(float newOffset)
    {
        _offset.z = _offManager.offset;

    // physics hand
        _intManager.handAccessorFunc = (frame) => TransformLeapHandModel(frame);        //****  muss ich das hier nochmal machen?

    // rigged hand 
        handRight.offset = _offset;
        handLeft.offset = -_offset;
    }

    Hand TransformLeapHandModel(Frame frame)
    {

        if (customHandIsRight)
        {
            hand = frame.Get(Chirality.Right);
            handCopy = hand;
            if (handCopy != null)
            {
                newPosition = handCopy.PalmPosition.ToVector3() + _offset;
                newRotation = handCopy.Rotation.ToQuaternion();
                handCopy.SetTransform(newPosition, newRotation);
            }
        }
        else
        {
            hand = frame.Get(Chirality.Left);
            handCopy = hand;
            if (handCopy != null)
            {
                newPosition = handCopy.PalmPosition.ToVector3() - _offset;
                newRotation = handCopy.Rotation.ToQuaternion();
                handCopy.SetTransform(newPosition, newRotation);
            }
        }
        return handCopy;
    }

}
