using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameButton : MonoBehaviour
{
    public void SwitchScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
