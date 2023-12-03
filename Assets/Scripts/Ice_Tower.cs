using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Tower : MonoBehaviour
{
    public float slow_speed = .02f;

    public float originial_speed;

    

//on trigger enter means that all enemies have to be spawned outside the field
    private void OnTriggerStay2D(Collider2D collision)
    {
    var enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            originial_speed = enemy.movespeed;
            enemy.movespeed = slow_speed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var enemy = collision.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.movespeed = originial_speed;
        }
    }
}
