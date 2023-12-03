using UnityEngine;

public class Base : MonoBehaviour
{
    public int maxHealth;

    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet> () != null)
        {
            currentHealth -= 10;
            healthBar.SetHealth(currentHealth);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            currentHealth -= 10;
            healthBar.SetHealth(currentHealth);
        }
    }
}
