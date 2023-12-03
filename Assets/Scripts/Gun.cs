using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
    Animator anim;
    float look_angle;
    Vector3 localpos;
    public GameObject BulletPrefab;
    //public AudioClip fire_sfx;
    //AudioSource source;
    public bool canShoot;

    public float spd = 5;
    //public float kb = 6;
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponentInParent<Player>();
        //source = GetComponent<AudioSource>();
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (player.state.IsName("death"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        */
        look_angle = Mathf.Atan2(player.look_dir.y, player.look_dir.x) * Mathf.Rad2Deg;
        localpos = transform.localPosition;
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
            //source.PlayOneShot(fire_sfx);

            GameObject b = Instantiate(BulletPrefab, transform.position + (transform.right * 0.5f), Quaternion.identity);
            Bullet bullet = b.GetComponent<Bullet>();
            //bullet.owner = player.gameObject.transform.GetChild(0).gameObject;
            bullet.dir = new Vector3(player.look_dir.x, player.look_dir.y).normalized;
            bullet.spd = spd;
            //bullet.kb = kb;
        }

    }
}
