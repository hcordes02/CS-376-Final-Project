using UnityEngine;

public class Base : MonoBehaviour
{
    public int maxHealth;

    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy> () != null)
        {
            currentHealth -= 1;
            healthBar.SetHealth(currentHealth);
        }
    }
}
