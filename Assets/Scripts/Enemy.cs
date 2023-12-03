using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Enemy component
/// </summary>
public class Enemy : MonoBehaviour
{
    SoundManager sound;

    public float movespeed = .03f;
    public float health = 5;

    private void Start()
    {
        sound = FindObjectOfType<SoundManager>();
    }

    void FixedUpdate()
    {
        var position = transform.position;
        position.x -= movespeed;
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            if (!collision.gameObject.GetComponent<Bullet>().strike)
            {
                collision.gameObject.GetComponent<Bullet>().strike = true;
                health -= 1;
                sound.Play_Hit();
                if (health <= 0)
                {
                    sound.Play_Death();
                    FindObjectOfType<Player>().money += 10;
                    Destroy(gameObject);
                }
            }
            

            
        }
    }
}
