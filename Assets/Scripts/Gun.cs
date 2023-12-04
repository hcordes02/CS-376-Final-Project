using UnityEngine;

/// <summary>
/// Gun component
/// </summary>
public class Gun : MonoBehaviour
{
    Player player;
    Animator anim;
    public GameObject BulletPrefab;

    Vector3 localpos;
    float look_angle;
    public bool canShoot;
    public float spd = 5;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
        canShoot = true;
    }

    void Update()
    {
        look_angle = Mathf.Atan2(player.look_dir.y, player.look_dir.x) * Mathf.Rad2Deg;
        localpos = transform.localPosition;

        if (player.state.IsName("build"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = true;
        }

        if (player.transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.rotation = Quaternion.Euler(0f, 0f, look_angle);
            localpos.z = -0.1f;
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.rotation = Quaternion.Euler(180f, 0f, -look_angle);
            localpos.z = 0.1f;
        }
        transform.localPosition = localpos;

        if (player.shoot_cooldown < 0.3)
        {
            if (player.shoot_cooldown == 0)
            {
                anim.speed = 100f;
            }
            else
            {
                anim.speed = 0.3f / player.shoot_cooldown;
            }
            
        }
        else
        {
            anim.speed = 1;
        }
        spd = player.bullet_spd;
    }

    public void Shoot()
    {
        if (canShoot == true)
        {
            anim.SetBool("shoot", true);

            GameObject b = Instantiate(BulletPrefab, transform.position + (transform.right * 0.5f), Quaternion.identity);

            Bullet bullet = b.GetComponent<Bullet>();

            bullet.dir = new Vector3(player.look_dir.x, player.look_dir.y).normalized;
            bullet.spd = spd;
        }
    }
}
