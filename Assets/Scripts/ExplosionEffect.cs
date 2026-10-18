using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    public Sprite[] frames;
    public float frameRate = 0.08f;

    private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float timer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (frames == null || frames.Length == 0)
        {
            Destroy(gameObject);
            return;
        }

        spriteRenderer.sprite = frames[0];
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= frameRate)
        {
            timer = 0f;
            currentFrame++;

            if (currentFrame >= frames.Length)
            {
                Destroy(gameObject);
                return;
            }

            spriteRenderer.sprite = frames[currentFrame];
        }
    }
}