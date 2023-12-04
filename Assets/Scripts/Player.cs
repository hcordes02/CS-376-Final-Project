using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/// <summary>
/// Player controller
/// </summary>
public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;
    public GameObject VFXPrefab;
    Gun gun;
    ToolBar toolbar;

    public AnimatorStateInfo state => anim.GetCurrentAnimatorStateInfo(0);
    float rand_chance => Random.Range(0f, 1f);

    public Vector2 move;
    public Vector2 vel;
    public Vector2 mouse_pos;
    public Vector2 look_dir;

    public float spd = 3;
    public float accel = 0.2f;
    public float fric = 0.3f;
    public int money = 0;
    public float shoot_cooldown = 0.6f;
    public float shoot_timer = 0;
    public float bullet_spd = 5;
    public bool shoot;
    public bool place;

    void Start()
    {
        gun = GetComponentInChildren<Gun>();

        toolbar = FindObjectOfType<ToolBar>();
    }

    void Update()
    {
        
        get_inputs();
        movement();
        
        if (shoot && shoot_timer == 0 && !state.IsName("build") && !state.IsName("lose"))
        {
            shoot_timer = shoot_cooldown;
            gun.Shoot();
        }
        if (toolbar.selected_tower != null)
        {
            anim.SetBool("build", true);
        }
        if (place && toolbar.selected_tower != null)
        {
            Instantiate(toolbar.selected_tower, mouse_pos, Quaternion.identity);
            toolbar.selected_tower = null;
            anim.SetBool("build", false);
        }

        if (state.IsName("run"))
        {
            if (rand_chance < 0.05f)
            {
                GameObject vfx_obj = Instantiate(VFXPrefab, transform.position + (-transform.up * Random.Range(0.32f, 0.2f)) + (transform.forward), Quaternion.identity);
                vfx_obj.GetComponent<Animator>().speed = Random.Range(1f, 2f);
                vfx_obj.GetComponent<Animator>().SetBool("dust", true);
            }
        }
    }
    
    void FixedUpdate()
    {
        timers();

        look_dir = (mouse_pos - rb.position);

        if (look_dir.normalized.x > 0.2f)
            transform.localScale = new Vector3(5, 5, 1);
        else if (look_dir.normalized.x < -0.2f)
        {
            transform.localScale = new Vector3(-5, 5, 1);
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }

    void timers()
    {
        shoot_timer = Util.Approach(shoot_timer, 0, Time.fixedDeltaTime);
    }

    void get_inputs()
    {

        move.x = Input.GetAxisRaw("Horizontal");
        move.y = Input.GetAxisRaw("Vertical");
        move = move.normalized;
        if (state.IsName("build") || state.IsName("lose"))
        {
            move = Vector2.zero;
        }

        shoot = Input.GetMouseButton(0);
        place = Input.GetMouseButton(1);

        mouse_pos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    void movement()
    {
        vel = rb.velocity;
        float accel_fric;

        if (move.magnitude != 0)
        {
            accel_fric = accel;
        }
        else
        {
            accel_fric = fric;
        }

        vel.x = Util.Approach(vel.x, move.x * spd, accel_fric);
        vel.y = Util.Approach(vel.y, move.y * spd, accel_fric);
        rb.velocity =  vel;
        
        if (vel.magnitude > 0.2)
        {
            anim.SetBool("moving", true);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }
}
