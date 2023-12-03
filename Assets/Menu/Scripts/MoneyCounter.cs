using TMPro;
using UnityEngine;

/// <summary>
/// Keep track of money
/// </summary>
[RequireComponent(typeof(TMP_Text))]
public class MoneyCounter : MonoBehaviour
{
    /// <summary>
    /// Store for MoneyCounter
    /// </summary>
    public static MoneyCounter Singleton;

    /// <summary>
    /// Money field
    /// </summary>
    private int money;

    /// <summary>
    /// Text field
    /// </summary>
    private TMP_Text moneyDisplay;

    /// <summary>
    /// Initialize Singleton and moneyDisplay
    /// </summary>
    private void Start()
    {
        Singleton = this;
        moneyDisplay = GetComponent<TMP_Text>();
    }

    /// <summary>
    /// Get current mone
    /// </summary>
    private void FixedUpdate()
    {
        money = FindObjectOfType<Player>().money;
        SetMoney(money);
    }

    /// <summary>
    /// Update money
    /// </summary>
    /// <param name="points"></param>
    public static void SetMoney(int money)
    {
        Singleton.MoneyInternal(money);
    }

    /// <summary>
    /// Set text to money
    /// </summary>
    /// <param name="delta"></param>
    private void MoneyInternal(int delta)
    {
        moneyDisplay.SetText("Money: " + money.ToString());
    }
}
