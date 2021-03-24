using LinkVibrationController;

public class LinkVibrationManager : LinkVibration
{
    
    public void VibrateShort(int index)
    {
        Vibrate(index, 500);
    }

    private void VibrateLong(int index)
    {
        Vibrate(index, 1000);
    }

}
