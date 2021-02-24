using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;
using Leap.Unity.Query;
using UnityEngine;
using System.Collections; 

public class LinkVibrationHandler : MonoBehaviour
{
    // private LinkVibrationManager controller;
    public float waitTime = 1.0f; 

// FIND FINGER INDEX
    private InteractionBehaviour intObj;

    private float _fingertipRadius = 0.01f;  // 1 cm
    private int _fingerIdx; 

    private bool _enableVibration;
    private bool[] _enableFingers; 

    void Start()
    {
     // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Vibration_OnTaskChangedHandler;

        // controller = GameObject.Find("VibrationManager").GetComponent<LinkVibrationManager>();
        intObj = gameObject.GetComponent<InteractionBehaviour>();

        // DEFAULT
        _enableVibration = false;
        _enableFingers = new bool[5] { true, true, true, true, true }; 
    }

// EVENTHANDLING
    private void Vibration_OnTaskChangedHandler(gameState newState)
    {
        if (newState == gameState.taskRunning)
        {
            _enableVibration = true; 
        }
        else
        {
            _enableVibration = false; 
        }
    }

 // FIND FINGER INDEX
    void FixedUpdate()
    {
        // if (controller)
        //{
            foreach (var contactingHand in intObj.contactingControllers
                                             .Query()
                                             .Select(controller => controller.intHand)
                                             .Where(intHand => intHand != null)
                                             .Select(intHand => intHand.leapHand))
            {
                foreach (var finger in contactingHand.Fingers)
                {
                    var fingertipPosition = finger.TipPosition.ToVector3();

                    if (intObj.GetHoverDistance(fingertipPosition) < _fingertipRadius)
                    {
                        switch (finger.Type)
                        {
                            case Finger.FingerType.TYPE_THUMB:
                                _fingerIdx = (int)Finger.FingerType.TYPE_THUMB; 
                                if (_enableFingers[_fingerIdx])
                                {
                                    _enableVibration = true;
                                    _enableFingers[_fingerIdx] = false; 
                                    StartCoroutine(DeactivateTwoSeconds(waitTime,_fingerIdx));
                                }
                                else
                                {
                                    _enableVibration = false;
                                }
                                break;

                            case Finger.FingerType.TYPE_INDEX:
                                _fingerIdx = (int)Finger.FingerType.TYPE_INDEX;
                                if (_enableFingers[_fingerIdx])
                                {
                                    _enableVibration = true;
                                    _enableFingers[_fingerIdx] = false;
                                    StartCoroutine(DeactivateTwoSeconds(waitTime, _fingerIdx));
                                }
                                else
                                {
                                    _enableVibration = false;
                                }
                                break; 

                            case Finger.FingerType.TYPE_MIDDLE:
                                _fingerIdx = (int)Finger.FingerType.TYPE_MIDDLE;
                                if (_enableFingers[_fingerIdx])
                                {
                                    _enableVibration = true;
                                    _enableFingers[_fingerIdx] = false;
                                    StartCoroutine(DeactivateTwoSeconds(waitTime, _fingerIdx));
                                }
                                else
                                {
                                    _enableVibration = false;
                                }
                                break;

                            case Finger.FingerType.TYPE_RING:
                                _fingerIdx = (int)Finger.FingerType.TYPE_RING;
                                if (_enableFingers[_fingerIdx])
                                {
                                    _enableVibration = true;
                                    _enableFingers[_fingerIdx] = false;
                                    StartCoroutine(DeactivateTwoSeconds(waitTime, _fingerIdx));
                                }
                                else
                                {
                                    _enableVibration = false;
                                }
                                break;

                            case Finger.FingerType.TYPE_PINKY:
                                _fingerIdx = (int)Finger.FingerType.TYPE_PINKY;
                                if (_enableFingers[_fingerIdx])
                                {
                                    _enableVibration = true;
                                    _enableFingers[_fingerIdx] = false;
                                    StartCoroutine(DeactivateTwoSeconds(waitTime, _fingerIdx));
                                }
                                else
                                {
                                    _enableVibration = false;
                                }
                                break;

                            default:
                                Debug.LogWarning("LinkVibrationHandler::FixedUpdate No valid finger ID");
                                break;
                        }
                    if (_enableVibration)
                    {
                        // controller.Vibrate(_fingerIdx, 1000);
                        Debug.Log("Found collision for fingertip: " + finger.Type);
                    } 
                    }
                }
            // }
        }
        
    }

    private IEnumerator DeactivateTwoSeconds(float waitTime, int idx)
    {
        yield return new WaitForSeconds(waitTime);
        _enableFingers[idx] = true; 
    }
}
