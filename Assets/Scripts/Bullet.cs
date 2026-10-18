
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    public float lifetime = 3f;
    public GameObject explosionPrefab;

    [HideInInspector]
    public string ownerTag = "";

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = transform.right * speed;
        }

        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Игнорируем объекты, если тег владельца задан
        if (!string.IsNullOrEmpty(ownerTag) &&
            other.transform.root.CompareTag(ownerTag))
        {
            return;
        }

        if (other.GetComponentInParent<Bullet>() != null)
            return;

        HealthSystem health =
            other.GetComponentInParent<HealthSystem>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }

        if (explosionPrefab != null)
        {
            Instantiate(
                explosionPrefab,
                transform.position,
                Quaternion.identity
            );
        }

        Destroy(gameObject);
    }
}
