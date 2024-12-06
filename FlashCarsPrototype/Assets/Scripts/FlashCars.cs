using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
public class FlashCars : MonoBehaviour
{
    public static float time = 0f;
    private static bool isTimerRunning = false;
    public Text timer;
    public Text questionT;
    public Text answer1T;
    public Text answer2T;
    public Text user;
    void Start() // for displaying the timer
    {
        // Display the elapsed time
        Debug.Log($"Loaded Elapsed Time: {time}");
        DisplayTime(time);
    }
    void Update()
    {
        // Update the timer if it's running
        if (isTimerRunning)
        {
            time += Time.deltaTime/5;
            DisplayTime(time);
        }
    }
    public void LoadGame()
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

    public void StartGame()
    {
        if (Car.position >= 0 && Car.position < 6)
        {
            UpdateQuestion();
            StartTimer();
        }
        user.text = Account.username;
    }

    public void PlayAgain()
    {
        ResetTimer();
        Car.ResetPosition();
        NPC.ResetNPCPosition();
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        ResetTimer();
        Car.ResetPosition();
        NPC.ResetNPCPosition();
        SceneManager.LoadScene("CreateAccount");
    }

    public void UpdateQuestion()
    {
        AnswerQuestion();
    }

    public static bool isWon()
    {
        if (Car.position >= 5 || NPC.position >= 5)
        {
            StopTimer();
            return true;
        }
        return false;
    }

    public static Dictionary<string, string[]> GenerateQuestion()
    {
        string subject = PlayerPrefs.GetString("SelectedSubject");
        string difficulty = PlayerPrefs.GetString("SelectedDifficulty");

        return Question.GetQuestionCatagory(subject, difficulty);
    }

    public void AnswerQuestion()
    {
        Dictionary<string, string[]> questions = GenerateQuestion();
        questionT.text = questions.ElementAt(Car.position).Key;
        answer1T.text = questions.ElementAt(Car.position).Value[0];
        answer2T.text = questions.ElementAt(Car.position).Value[1];
    }

    public void StartTimer()
    {
        // Start the timer
        isTimerRunning = true;
    }

    public static void StopTimer()
    {
        // Stop the timer
        isTimerRunning = false;
    }

    public static void ResetTimer()
    {
        // Reset the timer
        time = 0f;
    }

    private void DisplayTime(float time)
    {
        // Format the elapsed time as minutes:seconds
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        timer.text = $"{minutes:00}:{seconds:00}";
    }
}
