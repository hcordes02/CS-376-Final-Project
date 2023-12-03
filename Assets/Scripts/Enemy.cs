using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    Rigidbody2D hitbox;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        hitbox = GetComponent<Rigidbody2D>();
        health = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = gameObject.transform.position;
        position.x -= 0.1f;
        gameObject.transform.position = position;
    }
}
