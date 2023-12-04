using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Enemy component
/// </summary>
public class Enemy : MonoBehaviour
{
    SoundManager sound;
    public Animator anim;
    public GameObject VFXPrefab;
    public AnimatorStateInfo state => anim.GetCurrentAnimatorStateInfo(0);
    public float movespeed = .03f;
    public float health = 5;
    public bool explode = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        sound = FindObjectOfType<SoundManager>();
        
    }
    private void Update()
    {
        if (state.IsName("destroy"))
        {
            if (explode)
            {
                GameObject vfx_obj = Instantiate(VFXPrefab, transform.position, Quaternion.identity);
                vfx_obj.GetComponent<Animator>().SetBool("blast", true);
            }
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (!state.IsName("death"))
        {
            var position = transform.position;
            position.x -= movespeed;
            transform.position = position;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            if (!collision.gameObject.GetComponent<Bullet>().strike && !anim.GetBool("death"))
            {
                collision.gameObject.GetComponent<Bullet>().strike = true;
                anim.SetBool("hurt", true);
                health -= 1;
                sound.Play_Hit();
                if (health <= 0)
                {
                    sound.Play_Death();
                    FindObjectOfType<Player>().money += 5;
                    anim.SetBool("death", true);
                }
            }
            

            
        }
    }
}
