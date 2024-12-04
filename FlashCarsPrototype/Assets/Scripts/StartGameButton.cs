using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameButton : MonoBehaviour
{
    public void SwitchScene()
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
}
