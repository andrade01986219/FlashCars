using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Security.Cryptography;
using System.Text;
using System;
public class Account : MonoBehaviour
{
    public static string username;
    private string firstName;
    private string lastName;
    private string passwordHash;
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
        passwordHash = HashPassword(pass.text);

        // save account for goto login scene
        PlayerPrefs.SetString("username", username);
        PlayerPrefs.SetString("password", passwordHash);
        PlayerPrefs.Save();
        
        // goto login scene
        SceneManager.LoadScene("Login");
    }

    public void Login()
    {
        // get saved username and password
        string savedUsername = PlayerPrefs.GetString("username");
        string savedPasswordHash = PlayerPrefs.GetString("password");

        // hash text password to check for match
        string checkHash = HashPassword(pass.text);

        // check for match
        if (user.text == savedUsername && checkHash == savedPasswordHash)
        {
            username = user.text;

            // goto MainMenu scene
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            Debug.Log("Invalid username or password");
        }
        
    }

    private string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            // convert to bytes
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // convert bytes to string
            StringBuilder hashSB = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                hashSB.Append(b.ToString());
            }
            return hashSB.ToString();
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
