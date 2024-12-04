using UnityEngine;
using UnityEngine.UI;

public class DifficultySelection : MonoBehaviour
{
    public Dropdown dropdown;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("SelectedDifficulty"))
        {
            int difficultyIndex = PlayerPrefs.GetInt("SelectedDifficulty");
            if (difficultyIndex >= 0 && difficultyIndex < dropdown.options.Count)
            {
                dropdown.value = difficultyIndex;
            }
        }

        dropdown.onValueChanged.AddListener(SavedifficultySelection);
    }

    private void SavedifficultySelection(int difficulty)
    {
        PlayerPrefs.SetInt("SelectedDifficulty", difficulty);
        PlayerPrefs.SetString("SelectedDifficulty", dropdown.options[difficulty].text);
        PlayerPrefs.Save();

        Debug.Log($"Selected Difficulty: {dropdown.options[difficulty].text} (Index: {difficulty}) saved successfully.");
    }
}
