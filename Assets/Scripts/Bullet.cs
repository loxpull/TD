using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    public GameObject explosionEffect;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Enemy"))
        {
            if (other.CompareTag("Enemy"))
            {
                FindObjectOfType<GameScore>().AddScore(100);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            other.GetComponent<HealthSystem>().TakeDamage(damage);
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
}