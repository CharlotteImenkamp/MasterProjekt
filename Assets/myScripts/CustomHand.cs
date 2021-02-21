using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Interaction.Internal.InteractionEngineUtility;
using Leap.Unity.Interaction.Internal;
using Leap.Unity.RuntimeGizmos;
using Leap.Unity; 
using Leap.Unity.Attributes;

using Leap.Unity.Interaction;
using Leap.Unity.Query;


public class CustomHand: MonoBehaviour
{
    private InteractionHand manager;
    private Hand hand;
    private Hand handCopy;

    public bool customHandIsRight;
    public Vector3 _offset; 

    private Vector3 newPosition;
    private Quaternion newRotation = new Quaternion(0, 0, 0, 0);



    // Start is called before the first frame update
    void Start()
    {
        manager = gameObject.GetComponent<InteractionHand>();

        hand = new Hand();
        handCopy = new Hand();

        manager.handAccessorFunc = (frame) => TransformLeapHandModel(frame); 
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
