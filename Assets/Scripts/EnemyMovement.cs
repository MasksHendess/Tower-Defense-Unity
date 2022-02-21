using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float startSpeed = 10f;
    public float speed;
    private Transform target;
    private int wavepointIndex = 0;
    private LifeTracker lifeTracker;

    // Start is called before the first frame update
    void Start()
    {
        speed = startSpeed;
        target = Waypoints.waypoints[0];
        lifeTracker = LifeTracker.instance;
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);


        //if within 0.2f of waypoint, get next waypoint
        if(Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        // check if last waypoint 
        if(wavepointIndex >= Waypoints.waypoints.Length - 1)
        {
            Destroy(gameObject);
            lifeTracker.loseLife(1);
            return;
        }

        //set next waypoint
        wavepointIndex++;
        target = Waypoints.waypoints[wavepointIndex];
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
}
