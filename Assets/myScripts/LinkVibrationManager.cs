using LinkVibrationController;
using UnityEngine;

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
