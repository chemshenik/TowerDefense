using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(EnemyStats))]
public class Enemy : MonoBehaviour
{
    int target;
    Transform transform;
    EnemyStats stats;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = 0;
        transform = GetComponent<Transform>();
        stats = GetComponent<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        if (target < WayPoints.WayPoint.Length)
        {
            float distance = Vector2.Distance(transform.position, WayPoints.WayPoint[target].position);
            transform.position = Vector2.MoveTowards(transform.position, WayPoints.WayPoint[target].position, stats.speed * 0.005f);
            if (distance <= 0.1f)
            {
                GetNextPoint();
            }
        }
    }

    void GetNextPoint() {
        if (target < WayPoints.WayPoint.Length - 1)
            target++;
        else
        {
            player.GetComponent<Stats>().TakeDamage(stats.damage);
            Destroy(this.gameObject);
        }
    }
}
