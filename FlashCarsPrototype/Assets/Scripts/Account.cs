using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Account : MonoBehaviour
{
    public static string username;
    private string firstName;
    private string lastName;
    private static string password;
    private static int wins;

    public InputField first;
    public InputField last;
    public InputField user;
    public InputField pass;

    public Text UserNameText;
    public void CreateAccount()
    {
        firstName = first.text;
        lastName = last.text;
        username = user.text;
        password = pass.text;

        // save account for goto login scene
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetString("password", password);
        PlayerPrefs.Save();
        
        // goto login scene
        SceneManager.LoadScene("Login");
    }

    public void Login()
    {
        // get saved username and password
        string savedUsername = PlayerPrefs.GetString("username");
        string savedPassword = PlayerPrefs.GetString("password");

        // check for match
        if (user.text == savedUsername && pass.text == savedPassword)
        {
            username = user.text;
            password = pass.text;

            // goto MainMenu scene
            SceneManager.LoadScene("MainMenu");


        }
        else
        {
            Debug.Log("Invalid username or password");
        }
        
    }

    // OnEnable() called when MainMenu is loaded to display username
    void OnEnable()
    {
        if (UserNameText != null)
        {
            UserNameText.text = "Welcome " + username + "!";
        }
    }

    public int CheckStatistics()
    {
        return wins;
    }
}
