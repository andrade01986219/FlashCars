using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
public class FlashCars : MonoBehaviour
{
    public static float time = 0f;
    private static bool isTimerRunning = false;
    public Text timer;
    void Start() // for displaying the timer
    {
        // Display the elapsed time
        Debug.Log($"Loaded Elapsed Time: {time}");
        DisplayTime(time);
    }
    public void StartGame()
    {
        if (PlayerPrefs.HasKey("SelectedSubject") && PlayerPrefs.HasKey("SelectedDifficulty"))
        {
            string subject = PlayerPrefs.GetString("SelectedSubject");
            string difficulty = PlayerPrefs.GetString("SelectedDifficulty");
            if (subject != "Select" && difficulty != "Select")
            {
                SceneManager.LoadScene("GamePlay");
            }
            else
            {
                Debug.Log("No Subject or No Difficulty Selected");
            }
        }
        else
        {
            Debug.Log("No Subject or No Difficulty Selected");
        }
    }

    public static bool isWon()
    {
        if (Car.position >= 5)
        {
            return true;
        }
        return false;
    }

    public static Dictionary<string, string[]> GenerateQuestion()
    {
        return null;
    }

    public static string AnswerQuestion()
    {
        return null;
    }
    public static void UpdateTimer()
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

    private void DisplayTime(float time)
    {
        // Format the elapsed time as minutes:seconds
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        Debug.Log($"{time}");
        timer.text = $"{minutes:00}:{seconds:00}";
    }
}
