using UnityEngine;

/// <summary>
/// Bullet component
/// </summary>
public class Bullet : MonoBehaviour
{
    SoundManager sound;
    public GameObject vfxPrefab;
    public Animator anim;
    public AnimatorStateInfo state => anim.GetCurrentAnimatorStateInfo(0);
    public AnimatorStateInfo state_melee;

    public Vector3 dir;
    public float kb;
    public float lifetime;
    public bool front = true;
    bool strike = false;
    public float spd;

    void Start()
    {
        anim = GetComponent<Animator>();
        sound = FindObjectOfType<SoundManager>();
        sound.Play_Fire();
    }

    void Update()
    {
        if (state.IsName("destroy"))
        {
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (!strike)
        {
            transform.position += spd * dir * Time.fixedDeltaTime;
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y - 0.01f);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
