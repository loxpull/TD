using UnityEngine;

public class EnemyMovement:MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 2f;

    private int currentWaypointIndex = 0;

    void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            Transform targetWayPoint = waypoints[currentWaypointIndex];

            transform.position = Vector3.MoveTowards(
                transform.position,
                targetWayPoint.position,
                speed * Time.deltaTime
            );
            Vector3 direction = targetWayPoint.position - transform.position;

            float angle = Mathf.Atan2( direction.y,direction.x );

            if (Vector3.Distance(transform.position, targetWayPoint.position) < 0.1f)
            {
                currentWaypointIndex++;

                if (currentWaypointIndex >= waypoints.Length) { Destroy(gameObject); }
            }
        }

    }
}
