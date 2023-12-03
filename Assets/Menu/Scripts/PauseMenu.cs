using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Pause menu functions
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public void ToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
