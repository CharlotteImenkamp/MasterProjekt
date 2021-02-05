using LinkVibrationController;
using UnityEngine;

public class LinkVibrationTest : LinkVibration
{
    public void VibrateShort()
    {
        Vibrate(0, 500);
    }

    public void VibrateLong()
    {
        Vibrate(0, 1000);
    }
}
