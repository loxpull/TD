
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float range = 5f;
    public float fireRate = 1f;

    private float nextShotTime;

    void Update()
    {
        GameObject[] enemies =
            GameObject.FindGameObjectsWithTag("Enemy");

        GameObject nearestEnemy = null;
        float nearestDistance = range;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(
                transform.position,
                enemy.transform.position
            );

            if (distance <= nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy == null)
            return;

        if (Time.time >= nextShotTime)
        {
            if (bulletPrefab == null || firePoint == null)
                return;

            Vector2 direction =
                nearestEnemy.transform.position - firePoint.position;

            float angle = Mathf.Atan2(
                direction.y, direction.x
            ) * Mathf.Rad2Deg;

            Instantiate(
                bulletPrefab,
                firePoint.position,
                Quaternion.Euler(0, 0, angle)
            );

            nextShotTime = Time.time + 1f / Mathf.Max(0.1f, fireRate);
        }
    }
}
