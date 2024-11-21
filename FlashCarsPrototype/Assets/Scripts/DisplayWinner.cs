using UnityEngine;
using UnityEngine.SceneManagement;
public class DisplayWinner : MonoBehaviour
{
    public void WinnerScene()
    {
        SceneManager.LoadScene("Winner");
    }
}
