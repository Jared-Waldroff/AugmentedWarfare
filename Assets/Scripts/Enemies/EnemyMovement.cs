using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    public float speed = 2f;

    void Update()
    {
        if (waypoints.Length == 0) return;

        // Move towards the current waypoint
        transform.position = Vector3.MoveTowards(
            transform.position, 
            waypoints[currentWaypointIndex].position, 
            speed * Time.deltaTime
        );

        // Check if reached waypoint
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                Destroy(gameObject); // Reached end of path
            }
        }
    }
}
