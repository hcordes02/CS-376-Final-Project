using TMPro;
using UnityEngine;

/// <summary>
/// Keep track of base health
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class MoneyCounter : MonoBehaviour
{
    /// <summary>
    /// Store for HealthCounter
    /// </summary>
    public static MoneyCounter Singleton;

    /// <summary>
    /// Base health field
    /// </summary>
    private int money;

    /// <summary>
    /// Text field
    /// </summary>
    private TMP_Text moneyDisplay;

    /// <summary>
    /// Initialize Singleton and lifeDisplay
    /// </summary>
    private void Start()
    {
        Singleton = this;
        moneyDisplay = GetComponent<TMP_Text>();
    }

    /// <summary>
    /// Get current lives of Player
    /// </summary>
    private void FixedUpdate()
    {
        money = FindObjectOfType<Player>().money;
        SetMoney(money);
    }

    /// <summary>
    /// Update health and check if lost
    /// </summary>
    /// <param name="points"></param>
    public static void SetMoney(int money)
    {
        Singleton.MoneyInternal(money);
    }

    /// <summary>
    /// Set text to base health
    /// </summary>
    /// <param name="delta"></param>
    private void MoneyInternal(int delta)
    {
        moneyDisplay.SetText("Money: " + money.ToString());
    }
}
