using UnityEngine;

/// <summary>
/// BasicTower controller
/// </summary>
public class BasicTower : MonoBehaviour
{
    public GameObject tower_bullet;

    bool can_fire = true;
    float reload_speed = 1f;
    float bullet_speed = 5f;
    float shoot_timer = 0;

    private void OnTriggerStay2D(Collider2D collision)
    {
        //check that collision is an enemy
        //if yes, call fire in its direction
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            Vector2 to_enemy = collision.transform.position - transform.position;
            Vector3 ToEnemy = new Vector3(to_enemy.x, to_enemy.y, 0);
            Fire(ToEnemy); //called with angle
        }
    }

    void Fire(Vector3 fire_direction)
    {
        if (can_fire & shoot_timer < Time.time)
        {
            can_fire = false;
            Invoke("Reload", reload_speed);

            GameObject b = Instantiate(tower_bullet, transform.position, Quaternion.identity);

            Bullet bullet = b.GetComponent<Bullet>();
            bullet.dir = fire_direction.normalized;
            bullet.spd = bullet_speed;
            Reload();
        }

    }

    void Reload()
    {
        shoot_timer = Time.time + reload_speed;
        can_fire = true;
    }
}
