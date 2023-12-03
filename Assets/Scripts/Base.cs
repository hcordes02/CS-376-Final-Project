using UnityEngine;

public class Base : MonoBehaviour
{
    public int maxHealth;

    public int currentHealth;

    private HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            currentHealth -= 10;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
        }
    }
}
