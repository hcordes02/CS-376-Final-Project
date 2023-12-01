using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Tower : MonoBehaviour
{

    public GameObject tower_bullet;

    bool can_fire;
    float reload_speed = 2f;
    float bullet_speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check that collision is an enemy
        //if yes, call fire in its direction

        if (collision.tag == "enemy")
        {
            //get angle towards enemy
            Fire(Quaternion.identity); //called with angle
        }
    }

    void Fire(Quaternion towards_enemy){
        if (can_fire)
        {
            can_fire = false;
            Invoke("Reload", reload_speed);

            GameObject b = Instantiate(tower_bullet, transform.position, Quaternion.identity);


        }

    }

    void Reload()
    {
        can_fire = true;
    }
}
