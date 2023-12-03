using UnityEngine;

/// <summary>
/// Base object
/// </summary>
public class Base : MonoBehaviour
{
    private HealthBar healthBar;
    private MenuManager menuManager;

    public int maxHealth;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
        menuManager = FindObjectOfType<MenuManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null && !collision.gameObject.GetComponent<Bullet>().strike)
        {
            collision.gameObject.GetComponent<Bullet>().strike = true;
        }

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            currentHealth -= 10;
            healthBar.SetHealth(currentHealth);
            Destroy(collision.gameObject);
            if (currentHealth <= 0 )
            {
                menuManager.ReturnToMenu();
            }
        }
    }
}
