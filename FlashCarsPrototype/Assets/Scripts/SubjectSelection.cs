using UnityEngine;
using UnityEngine.UI;

public class SubjectSelection : MonoBehaviour
{
    public Dropdown dropdown;

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        if (PlayerPrefs.HasKey("SelectedSubject"))
        {
            int subjectIndex = PlayerPrefs.GetInt("SelectedSubject");
            if (subjectIndex >= 0 && subjectIndex < dropdown.options.Count)
            {
                dropdown.value = subjectIndex;
            }
        }

        dropdown.onValueChanged.AddListener(SaveSubjectSelection);
    }

    private void SaveSubjectSelection(int subject)
    {
        PlayerPrefs.SetInt("SelectedSubject", subject);
        PlayerPrefs.SetString("SelectedSubject", dropdown.options[subject].text);
        PlayerPrefs.Save();

        Debug.Log($"Selected Subject: {dropdown.options[subject].text} (Index: {subject}) saved successfully.");
    }
}
