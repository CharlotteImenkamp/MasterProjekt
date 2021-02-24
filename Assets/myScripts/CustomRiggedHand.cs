using UnityEngine;
using Leap.Unity;
using Leap;


public class CustomRiggedHand : RiggedHand
{

    public Vector3 _riggedHandOffset;
    private Vector3 _newPosition;
    private Quaternion _newRotation;


    public override void SetLeapHand(Hand hand)
    {
        hand_ = hand;
        _newPosition = hand_.PalmPosition.ToVector3() + _riggedHandOffset;
        _newRotation = hand_.Rotation.ToQuaternion();
        hand_.SetTransform(_newPosition, _newRotation);

        for (int i = 0; i < fingers.Length; ++i)
        {
            if (fingers[i] != null)
            {
                fingers[i].SetLeapHand(hand_);
            }
        }
    }
}
