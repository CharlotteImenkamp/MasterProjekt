using LinkVibrationController;


public class VibrationManager : LinkVibration
{
// START
    void Start()
    {
     // EVENTHANDLING
        GameManager.Instance.OnTaskChanged += Vibration_OnTaskChangedHandler;

    }

// UPDATE
    void Update()
    {
        
    }


// EVENTHANDLING
    private void Vibration_OnTaskChangedHandler(gameState state)
    {
    // TASK RUNNING
        // Vibration active

    // TASK SWITCHING
        // Vibration inactive

    // NO TASK RUNNING
        // Vibration active
    }
}
