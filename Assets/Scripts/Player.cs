using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public int HP = 3;

    public float spd = 3;
    public float accel = 0.2f;
    public float fric = 0.3f;



    public float shoot_cooldown = 0.6f;
    public float shoot_timer = 0;

    public float bullet_spd = 5;

    public Rigidbody2D rb;
    public Camera cam;
    public Animator anim;
    Gun gun;
    float rand_chance => Random.Range(0f, 1f);
    public AnimatorStateInfo state => anim.GetCurrentAnimatorStateInfo(0);



    public Vector2 move;
    public Vector2 vel;
    public Vector2 mouse_pos;
    public Vector2 look_dir;
    public bool shoot;

    //public GameObject end;
    public GameObject VFXPrefab;


    void Start()
    {
        gun = GetComponentInChildren<Gun>();

    }

    // Update is called once per frame
    void Update()
    {
        get_inputs();
        movement();
        
        if (shoot && shoot_timer == 0)
        {
            shoot_timer = shoot_cooldown;
            gun.Shoot();
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
            transform.localScale = new Vector3(4, 4, 1);
        else if (look_dir.normalized.x < -0.2f)
        {
            transform.localScale = new Vector3(-4, 4, 1);
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

        shoot = Input.GetMouseButton(0);
            
        
        

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
