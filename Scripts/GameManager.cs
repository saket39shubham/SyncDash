using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Prefabs")]
    public GameObject obstaclePrefab;
    public GameObject orbPrefab;

    [Header("Settings")]
    public int poolSize = 20;
    public float spawnZ = 20f;
    public float spawnInterval = 2f;

    private List<GameObject> obstaclePool = new List<GameObject>();
    private List<GameObject> orbPool = new List<GameObject>();

    void Awake()
    {
        Instance = this;

        // Create pools
        for (int i = 0; i < poolSize; i++)
        {
            GameObject o = Instantiate(obstaclePrefab);
            o.SetActive(false);
            obstaclePool.Add(o);

            GameObject orb = Instantiate(orbPrefab);
            orb.SetActive(false);
            orbPool.Add(orb);
        }
    }
    void Start()
    {
        ResetPools();
        InvokeRepeating(nameof(Spawn), 1f, spawnInterval);
    }
    void Update()
    {
        MoveObjects(obstaclePool);
        MoveObjects(orbPool);
    }

    void Spawn()
    {
        float laneX = PlayerController.Instance.transform.position.x;

        float spawnDistanceAhead = 25f;

        float spawnZPos = PlayerController.Instance.transform.position.z + spawnDistanceAhead;

        Vector3 pos = new Vector3(laneX, 1f, spawnZPos);

        GameObject obstacle = GetFromPool(obstaclePool);
        obstacle.transform.position = pos;
        obstacle.SetActive(true);

        if (Random.value > 0.3f)
        {
            GameObject orb = GetFromPool(orbPool);
            orb.transform.position = pos + Vector3.up * 2f;
            orb.SetActive(true);
        }
    }

    GameObject GetFromPool(List<GameObject> pool)
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(pool[0].gameObject);
        newObj.SetActive(false);
        pool.Add(newObj);
        return newObj;
    }

    void MoveObjects(List<GameObject> pool)
    {
        float speed = PlayerController.Instance.forwardSpeed;

        foreach (var obj in pool)
        {
            if (obj.activeInHierarchy)
            {
                obj.transform.Translate(Vector3.back * speed * Time.deltaTime);

                if (obj.transform.position.z < PlayerController.Instance.transform.position.z - 10f)
                {
                    obj.SetActive(false);
                }
            }
        }
    }
    void ResetPools()
    {
        foreach (var obj in obstaclePool)
            obj.SetActive(false);

        foreach (var obj in orbPool)
            obj.SetActive(false);
    }
}