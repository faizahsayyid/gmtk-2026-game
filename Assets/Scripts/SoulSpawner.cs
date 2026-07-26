using UnityEngine;

public class SoulSpawner : MonoBehaviour
{
    public GameObject soul;
    public GameObject badSoul;
    public float minX = -3f;
    public float maxX = 3f;
    public float baseSpeed = 3f;
    public float speedIncreasePerWave = 1f;
    public float spawnInterval = 0.15f;
    public GameState gameState;

    void OnEnable()
    {
        if (gameState != null)
        {
            gameState.OnWave += HandleWave;
        }
    }

    void OnDisable()
    {
        if (gameState != null)
        {
            gameState.OnWave -= HandleWave;
        }
    }

    void HandleWave(int wave)
    {
        int spawnNumber = Mathf.Max(1, (int)Mathf.Pow(2f, wave));
        float speed = baseSpeed + (wave * speedIncreasePerWave);

        for (int i = 0; i < spawnNumber; i++)
        {
            float delay = i * spawnInterval;
            StartCoroutine(SpawnSoulWithDelay(delay, speed));
        }
    }

    private System.Collections.IEnumerator SpawnSoulWithDelay(float delay, float speed)
    {
        yield return new WaitForSeconds(delay);

        Vector3 pos = transform.position;
        pos.x = Random.Range(minX, maxX);

        GameObject spawnedSoul = Instantiate(soul, pos, Quaternion.identity);
        SoulController soulController = spawnedSoul.GetComponent<SoulController>();
        if (soulController != null)
        {
            soulController.speed = speed;
        }
    }
}