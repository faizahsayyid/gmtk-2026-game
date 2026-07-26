using UnityEngine;

public class HaloScript : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 10f;
    public float lifetime = 3f;

    public PlayerState playerState;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
        Vector2 direction = Vector2.up;
        rb.linearVelocity = direction * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandleSoulCollision(collision.collider);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        HandleSoulCollision(col);
    }

    private void HandleSoulCollision(Collider2D col)
    {
        if (col != null && col.CompareTag("Soul"))
        {
            Destroy(gameObject);
            return;
        } 

        if (col != null && col.CompareTag("BadSoul"))
        {
            playerState.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
