using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
//using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update


    Sound_Manager sound;

    //public GameObject owner;
    //public Animator owner_anim;
    //public AnimatorStateInfo owner_state;
    //public Vector3 owner_position;
    //public Rigidbody2D rb;
    public float kb;
    public float lifetime;
    public bool front = true;
    Vector2 opp_offset;
    bool strike = false;
    public GameObject vfxPrefab;

    public Animator anim;
    public AnimatorStateInfo state => anim.GetCurrentAnimatorStateInfo(0);
    public AnimatorStateInfo state_melee;
    public Vector3 dir;
    public float spd;


    void Start()
    {
        anim = GetComponent<Animator>();

        sound = FindObjectOfType<Sound_Manager>();
        sound.Play_Fire();
    }

    // Update is called once per frame
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    
    }
}
