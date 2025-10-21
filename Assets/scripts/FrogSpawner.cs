using UnityEngine;

public class FrogSpawner : MonoBehaviour
{
    public GameObject frogPrefab;
    public float spawnInterval = 2f;
    public float xRange = 8f;
    public float yRange = 4f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnFrog), 1f, spawnInterval);
    }

    void SpawnFrog()
    {
        float x = Random.Range(-xRange, xRange);
        float y = Random.Range(-yRange, yRange);
        Vector2 spawnPos = new Vector2(x, y);
        Instantiate(frogPrefab, spawnPos, Quaternion.identity);
        Debug.Log($"Spawned frog at {spawnPos}");
    }
}
