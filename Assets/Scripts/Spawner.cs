using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    float spawn_interval = 10f;
    float spawn_timer;
    float rand_chance => Random.Range(0f, 1f);
    float spawn_chance = 0.1f;
    float rand_pos => Random.Range(-2f, 2f);

    void Update()
    {
        if (spawn_timer == 0)
        {
            spawn_interval = Util.Approach(spawn_interval, 4f, 0.1f);
            if (spawn_interval == 4)
            {
                spawn_chance = Util.Approach(spawn_chance, 0.8f, 0.05f);
            }
        }

    }

    private void FixedUpdate()
    {
        spawn_timer = Util.Approach(spawn_timer, 0, Time.deltaTime);
        if (spawn_timer == 0 && rand_chance < spawn_chance)
        {
            Instantiate(enemy, new Vector2(8, rand_pos), Quaternion.identity);
            spawn_timer = spawn_interval;
        }

    }
}