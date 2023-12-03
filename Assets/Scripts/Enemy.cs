using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movespeed = .03f;
    public float health = 5;

    private void Start()
    {
        
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
            Destroy(collision.gameObject);
            health -= 1;
            if (health <= 0)
            {
                FindObjectOfType<Player>().money += 10;
                Destroy(gameObject);
            }
        }
    }
}
