using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity;
using Leap.Unity.Interaction;
using Leap.Unity.Query;
//using LinkVibrationController; 

public class LinkVibrationHandler : MonoBehaviour
{
    private LinkVibrationManager controller;

// FIND FINGER INDEX
    private InteractionBehaviour intObj;

    private Collider[] _collidersBuffer = new Collider[16];
    private float _fingertipRadius = 0.01f;  // 1 cm
    int vibrationIndex; 

    void Start()
    {
        controller = GameObject.Find("LinkVibrationManager").GetComponent<LinkVibrationManager>();
        intObj = gameObject.GetComponent<InteractionBehaviour>();
    }

// FIND FINGER INDEX
    void FixedUpdate()
    {
        foreach (var contactingHand in intObj.contactingControllers
                                             .Query()
                                             .Select(controller => controller.intHand)
                                             .Where(intHand => intHand != null)
                                             .Select(intHand => intHand.leapHand))
        {

            foreach (var finger in contactingHand.Fingers)
            {
                var fingertipPosition = finger.TipPosition.ToVector3();

                // If the distance from the fingertip and the object is less
                // than the 'fingertip radius', the fingertip is touching the object.
                if (intObj.GetHoverDistance(fingertipPosition) < _fingertipRadius)
                {
                    switch(finger.Type)
                    {
                        case Leap.Finger.FingerType.TYPE_THUMB:
                            vibrationIndex = 0;
                            break;
                        case Leap.Finger.FingerType.TYPE_INDEX:
                            vibrationIndex = 1;
                            break;
                        case Leap.Finger.FingerType.TYPE_MIDDLE:
                            vibrationIndex = 2;
                            break;
                        case Leap.Finger.FingerType.TYPE_RING:
                            vibrationIndex = 3;
                            break;
                        case Leap.Finger.FingerType.TYPE_PINKY:
                            vibrationIndex = 4;
                            break;
                        default:
                            Debug.LogWarning("LinkVibrationHandler::FixedUpdate No valid finger ID");
                            break; 
                    }
                    controller.Vibrate(vibrationIndex, 1000);
                    Debug.Log("Found collision for fingertip: " + finger.Type);

                }
            }
        }
    }
}
