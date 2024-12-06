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
    public void CreateAccount()
    {
        firstName = first.text;
        lastName = last.text;
        username = user.text;
        password = pass.text;

        SceneManager.LoadScene("Login");
    }

    public void Login()
    {
        username = user.text;
        password = pass.text;

        SceneManager.LoadScene("MainMenu");
    }

    public int CheckStatistics()
    {
        return wins;
    }
}
