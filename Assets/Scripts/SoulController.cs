using UnityEngine;
using System.Collections;


public class SoulController : MonoBehaviour
{
     public Animator animator;
     public float ascensionDelay = 1.5f;
    
    public float speed = 3f;
    public PlayerState playerState;

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

        float offScreenY = -15f;
        if (Camera.main != null)
        {
            Vector3 bottomViewport = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, Mathf.Abs(Camera.main.transform.position.z)));
            offScreenY = bottomViewport.y - 1f;
        }

        if (transform.position.y < offScreenY)
        {
            if (playerState != null)
            {
                playerState.RegisterLostSoul();
            }

            Destroy(gameObject);
        }
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
