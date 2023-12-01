using TMPro;
using UnityEngine;

/// <summary>
/// Keep track of base health
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class HealthCounter : MonoBehaviour
{
    /// <summary>
    /// Store for HealthCounter
    /// </summary>
    public static HealthCounter Singleton;

    /// <summary>
    /// Base health field
    /// </summary>
    private float health;

    /// <summary>
    /// Text field
    /// </summary>
    private TMP_Text healthDisplay;

    public bool gameOver;

    /// <summary>
    /// Initialize Singleton and lifeDisplay
    /// </summary>
    private void Start()
    {
        Singleton = this;
        healthDisplay = GetComponent<TMP_Text>();
        gameOver = true;
    }

    /// <summary>
    /// Get current lives of Player
    /// </summary>
    private void FixedUpdate()
    {
        health = FindObjectOfType<Base>().currentHealth;
        SetHealth(health);
    }

    /// <summary>
    /// Update health and check if lost
    /// </summary>
    /// <param name="points"></param>
    public static void SetHealth(float health)
    {
        Singleton.HealthInternal(health);
        Singleton.CheckEnd();
    }

    /// <summary>
    /// Set text to base health
    /// </summary>
    /// <param name="delta"></param>
    private void HealthInternal(float delta)
    {
        healthDisplay.SetText("Lives: " + health.ToString());
    }

    /// <summary>
    /// Check if player has died
    /// </summary>
    private void CheckEnd()
    {
        if (health <= 0)
        {
            gameOver = true;
        }
    }
}
