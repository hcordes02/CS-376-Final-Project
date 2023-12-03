using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Pause Menu and End Game Controller
/// </summary>
public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// Field for the pause menu
    /// </summary>
    public PauseMenu menu;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menu.gameObject.SetActive(!menu.gameObject.activeSelf);
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
