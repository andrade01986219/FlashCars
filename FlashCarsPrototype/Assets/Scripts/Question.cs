using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{
    public Text subject;

    private void Start()
    {
        displaySelections();
    }
    private void displaySelections()
    {
        if (PlayerPrefs.HasKey("SelectedSubject") && PlayerPrefs.HasKey("SelectedDifficulty"))
        {
            string selectedSubject = PlayerPrefs.GetString("SelectedSubject");
            string selectedDifficulty = PlayerPrefs.GetString("SelectedDifficulty");
            subject.text = $"Selected Subject: {selectedSubject}\nSelected Difficulty: {selectedDifficulty}";
        }
        else
        {
            subject.text = "No subject selected.";
        }
    }
}
