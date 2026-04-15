using UnityEngine;

public class Spawner : MonoBehaviour
{
    public ObjectPool obstaclePool;
    public ObjectPool orbPool;

    public float spawnZ = 20f;
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnInterval);
    }

    void Spawn()
    {
        Vector3 pos = new Vector3(Random.Range(-2, 2), 1, spawnZ);

        GameObject obstacle = obstaclePool.GetObject();
        obstacle.transform.position = pos;

        if (Random.value > 0.5f)
        {
            GameObject orb = orbPool.GetObject();
            orb.transform.position = pos + Vector3.up * 2;
        }
    }
}