using UnityEngine;

public class HaloCollectableSpawner : MonoBehaviour
{
    public GameObject haloCollectable;
    public float spawnInterval = 2f;
    public float minX = -3f;
    public float maxX = 3f;
    public GameState gameState;

    private float timer;

    void Update()
    {
        if (!gameState.GetIsCoolDown())
        {
            return;
        }
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;

            Vector3 pos = transform.position;
            pos.x = Random.Range(minX, maxX);

            Instantiate(
                haloCollectable,
                pos,
                Quaternion.identity
            );
        }
    }
}