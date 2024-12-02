using UnityEngine;
using UnityEngine.UI;

public class DisplaySelectedSubject : MonoBehaviour
{
    public Text subjectQuestion;

    private void Start()
    {
        if (PlayerPrefs.HasKey("SelectedSubject") && PlayerPrefs.HasKey("SelectedDifficulty"))
        {
            string subject = PlayerPrefs.GetString("SelectedSubject");
            string difficulty = PlayerPrefs.GetString("SelectedDifficulty");
            subjectQuestion.text = $"Selected Subject: {subject}\nSelected Difficulty: {difficulty}";
        }
        else
        {
            subjectQuestion.text = "No subject selected.";
        }
    }
}
