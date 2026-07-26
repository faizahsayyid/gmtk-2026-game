using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public Transform haloSpawnPoint;
    public GameObject halo;
    public Animator animator;
    public PlayerState playerState;

    

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private InputSystem_Actions controls;

    void OnEnable()
    {
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; 

        playerState.ResetHalos();

        controls = new InputSystem_Actions();
        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        // Using jump for shoot
        controls.Player.Jump.performed += ctx => OnShoot();
    }

    void FixedUpdate()
    {
        Vector2 xOnly = new Vector2(1, 0);
        Vector2 movement = moveInput.normalized * xOnly * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    void OnShoot()
    {
    
        if (!playerState.CanUseHalo()) return;

        playerState.UseHalo();
        animator.SetTrigger("Cast");
        Object.Instantiate(
                halo, 
                haloSpawnPoint.transform.position, 
                haloSpawnPoint.transform.rotation
            );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        HandleSoulCollision(collision.collider);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HandleSoulCollision(other);
    }

    private void HandleSoulCollision(Collider2D other)
    {
        if (other != null && (other.CompareTag("Soul") || other.CompareTag("BadSoul")))
        {
            playerState.TakeDamage(1);
        }
    }

}
