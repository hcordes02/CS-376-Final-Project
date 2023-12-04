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
    float game_over_timer = 0;
    bool game_over = false;

    void Start()
    {
        game_over_timer = 0;
        currentHealth = maxHealth;
        healthBar = FindObjectOfType<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
        menuManager = FindObjectOfType<MenuManager>();
    }
    private void Update()
    {
        if (game_over)
        {
            game_over_timer += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null && !collision.gameObject.GetComponent<Bullet>().strike)
        {
            collision.gameObject.GetComponent<Bullet>().strike = true;
        }

        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            if (!collision.gameObject.GetComponent<Enemy>().state.IsName("death"))
            {
                currentHealth -= 10;
                healthBar.SetHealth(currentHealth);
                collision.gameObject.GetComponent<Enemy>().explode = true;
                collision.gameObject.GetComponent<Enemy>().anim.SetBool("death", true);
            }
                
            
            if (currentHealth <= 0 )
            {
                game_over = true;
                FindObjectOfType<Player>().anim.SetBool("lose", true);

            }
            if (game_over_timer > 1f)
            {
                menuManager.ReturnToMenu();
            }
        }
    }
}
