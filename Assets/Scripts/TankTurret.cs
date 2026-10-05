using UnityEngine;

public class TankTurret : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5f;
    public float detectionRange = 10f;

    void Update()
    {
        FindNearestTarget();
        if (target != null)
        {
            RotateTurretTowardsTarget();
        }
    }

    void FindNearestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = detectionRange;
        Transform closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy.transform;
            }
        }
        target = closestEnemy;
    }

    void RotateTurretTowardsTarget()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), rotationSpeed * Time.deltaTime);
    }
}