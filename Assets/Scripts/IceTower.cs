using UnityEngine;

/// <summary>
/// IceTower component
/// </summary>
public class IceTower : MonoBehaviour
{
    //public float slow_speed = .02f;

    //public float originial_speed;
    public Animator anim;
    public float slow_factor = 1.5f;
    //public SpriteRenderer circle => GetComponentInChildren<SpriteRenderer>()
    private void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        var enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            anim.SetInteger("enemies", anim.GetInteger("enemies") + 1);
            enemy.movespeed /= slow_factor;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        var enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            anim.SetInteger("enemies", anim.GetInteger("enemies") - 1);
            enemy.movespeed *= slow_factor;
        }
    }
}
