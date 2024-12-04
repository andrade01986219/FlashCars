using UnityEngine;
using UnityEngine.UI;

public class DisplayTimer : MonoBehaviour
{
    public Text timer; // Assign the Text UI element in the Inspector

    void Start()
    {
        // Display the elapsed time
        Debug.Log($"Loaded Elapsed Time: {GameTimer.time}");
        DisplayTime(GameTimer.time);
    }

    private void DisplayTime(float time)
    {
        // Format the elapsed time as minutes:seconds
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        timer.text = $"{minutes:00}:{seconds:00}";
    }
}
