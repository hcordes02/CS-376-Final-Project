using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main Menu Controller
/// </summary>
public class MainMenu : MonoBehaviour
{
    public void PLayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
