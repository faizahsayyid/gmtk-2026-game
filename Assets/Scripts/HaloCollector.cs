using UnityEngine;

public class HaloCollector : MonoBehaviour
{
    public PlayerState playerState;
    public int numHalos = 5;

    public float speed = 3f;

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.x < -15f)
            Destroy(gameObject);
    }

    // TODO: handle collisions
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerState.CollectHalo(numHalos);
            Destroy(gameObject);
        }
    }
}
