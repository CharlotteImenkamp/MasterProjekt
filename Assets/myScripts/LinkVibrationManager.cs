using LinkVibrationController;
using UnityEngine;
using Leap.Unity; 

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

}
