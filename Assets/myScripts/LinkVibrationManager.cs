using LinkVibrationController;
using UnityEngine;
using Leap.Unity; 

// https://developer-archive.leapmotion.com/documentation/v2/unity/unity/Unity_DetectionUtilities.html

public class LinkVibrationManager : LinkVibration
{
    
    private void VibrateShort(int index)
    {
        Vibrate(index, 500);
    }

    private void VibrateLong(int index)
    {
        Vibrate(index, 1000);
    }

    public void VibrateOnCollision(RiggedFinger riggedFinger )
    {
        // wenn 
        if (riggedFinger.fingerType == Leap.Finger.FingerType.TYPE_THUMB)
        {
            VibrateShort(0);
        }
        else if(riggedFinger.fingerType == Leap.Finger.FingerType.TYPE_INDEX)
        {
            VibrateShort(1); 
        }
        else if (riggedFinger.fingerType == Leap.Finger.FingerType.TYPE_MIDDLE)
        {
            VibrateShort(2);
        }
        else if (riggedFinger.fingerType == Leap.Finger.FingerType.TYPE_RING)
        {
            VibrateShort(3);
        }
        else if (riggedFinger.fingerType == Leap.Finger.FingerType.TYPE_PINKY)
        {
            VibrateShort(4);
        }
    }
}
