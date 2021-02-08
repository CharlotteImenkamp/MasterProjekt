using LinkVibrationController;
using UnityEngine;

// https://developer-archive.leapmotion.com/documentation/v2/unity/unity/Unity_DetectionUtilities.html

public class LinkVibrationManager : LinkVibration
{
    
    public void VibrateShort(int index)
    {
        Vibrate(index, 500);
    }

    public void VibrateLong(int index)
    {
        Vibrate(index, 1000);
    }
}
