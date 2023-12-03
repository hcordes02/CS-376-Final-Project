using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// HealthBar Controller
/// </summary>
public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private void Start()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
