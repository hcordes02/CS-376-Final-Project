using UnityEngine;

/// <summary>
/// IceTower component
/// </summary>
public class IceTower : MonoBehaviour
{
    //public float slow_speed = .02f;

    //public float originial_speed;

    public float slow_factor = 1.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.movespeed /= slow_factor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.movespeed *= slow_factor;
        }
    }
}
