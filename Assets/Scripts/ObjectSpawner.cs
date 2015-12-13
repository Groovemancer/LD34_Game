#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public List<SpawnedObject> spawnObjects;

    public float spawnRadius = 1f;

    public float spawnFrequency;    
    [Tooltip("Adds a little randomness to the spawn frequency so it isn't exactly at set intervals.")]
    public float frequencyVariance;

    private float spawnTimer = 0f;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        }
        if (spawnTimer <= 0)
        {
            SpawnRandomObject();
            SetSpawnTimer();
        }
    }

    private void SetSpawnTimer()
    {
        float freq = Random.Range(-frequencyVariance, frequencyVariance) + spawnFrequency;
        spawnTimer = freq;
    }

    private void SpawnRandomObject()
    {
        foreach (SpawnedObject obj in spawnObjects)
        {
            float r = Random.Range(1f, 100f);
            if (r <= obj.chanceToSpawn)
            {
                SpawnObject(obj.spawn);
            }
        }
    }

    private void SpawnObject(GameObject obj)
    {
        Vector2 randomPoint = Random.insideUnitCircle * spawnRadius;

        GameObject.Instantiate(obj, transform.position + new Vector3(randomPoint.x, randomPoint.y, 0), Quaternion.identity);
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "SpawnerIcon.png");
        Handles.color = Color.green;
        Handles.DrawWireDisc(transform.position, transform.forward, spawnRadius);
    }
#endif
}
