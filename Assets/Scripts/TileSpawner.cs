#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using System.Collections;

public class TileSpawner : MonoBehaviour
{
    public GameObject tile;
    public float frequency;
    private float timer = 0f;

    // Use this for initialization
    void Start()
    {
        Instantiate(tile, transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0)
        {
            Instantiate(tile, transform.position, Quaternion.identity);
            timer = frequency;
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "SpawnerIcon.png");
    }
#endif
}
