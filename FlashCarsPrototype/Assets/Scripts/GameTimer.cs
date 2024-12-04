using UnityEngine;

public class GameTimer : MonoBehaviour
{
    public static float time = 0f; // Time elapsed since the timer started
    private bool isTimerRunning = false; // Flag to track if the timer is running

    void Update()
    {
        // Update the timer if it's running
        if (isTimerRunning)
        {
            time += Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        // Start the timer
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        // Stop the timer
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        // Reset the timer
        time = 0f;
    }
}
