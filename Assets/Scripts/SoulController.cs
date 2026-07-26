using UnityEngine;
using System.Collections;


public class SoulController : MonoBehaviour
{
     public Animator animator;
     public float ascensionDelay = 1.5f;
    
    public float speed = 3f;

    private Collider2D soulCollider;
    private bool isAscending;

    private void Awake()
    {
        soulCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAscending)
        {
            return;
        }

        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.x < -15f)
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleCollision(collision.collider);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HandleCollision(other);
    }

    private void HandleCollision(Collider2D other)
    {
        if (isAscending || other == null)
        {
            return;
        }

        if (other.CompareTag("Halo"))
        {
            isAscending = true;
            if (soulCollider != null)
            {
                soulCollider.enabled = false;
            }

            animator.SetTrigger("Ascend");
            StartCoroutine(HandleAscend());
        }
    }

    private IEnumerator HandleAscend()
    {
        yield return new WaitForSeconds(ascensionDelay); 
        Destroy(gameObject);
    }
}
