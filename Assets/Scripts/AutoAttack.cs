
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [Header("Target")]
    public string targetTag = "EnemyTank";
    public float range = 5f;

    [Header("Attack")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;

    [Header("Aim")]
    public Transform turret;
    public bool rotateTurret = true;

    private float nextShotTime;

    void Update()
    {
        GameObject target = FindTarget();

        if (target == null)
            return;

        Vector2 direction =
            target.transform.position - transform.position;

        if (rotateTurret && turret != null)
        {
            float angle = Mathf.Atan2(
                direction.y, direction.x
            ) * Mathf.Rad2Deg;

            turret.rotation =
                Quaternion.Euler(0, 0, angle);
        }

        if (Time.time >= nextShotTime)
        {
            Shoot(direction);
            nextShotTime = Time.time + 1f / Mathf.Max(0.1f, fireRate);
        }
    }

    GameObject FindTarget()
    {
        GameObject[] targets =
            GameObject.FindGameObjectsWithTag(targetTag);

        GameObject nearest = null;
        float nearestDistance = range;

        foreach (GameObject target in targets)
        {
            float distance = Vector2.Distance(
                transform.position,
                target.transform.position
            );

            if (distance <= nearestDistance)
            {
                nearestDistance = distance;
                nearest = target;
            }
        }

        return nearest;
    }

    void Shoot(Vector2 direction)
    {
        if (bulletPrefab == null || firePoint == null)
            return;

        float angle = Mathf.Atan2(
            direction.y, direction.x
        ) * Mathf.Rad2Deg;

        Instantiate(
            bulletPrefab,
            firePoint.position,
            Quaternion.Euler(0, 0, angle)
        );
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
