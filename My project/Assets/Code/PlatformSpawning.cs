using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSpawning : MonoBehaviour
{
    public BoxCollider2D SpawnerBox;
    List<Transform> platforms;
    public Transform bodyPrefab;
    public float spawnInterval = 1.5f; // Time between spawns

    void Start()
    {
        platforms = new List<Transform>();        //Log all existing nemies
        StartCoroutine(SpawnPlatforms());         //Enables IEnumerator to function
    }

    IEnumerator SpawnPlatforms()                  //Allows the use of delays
    {
        while (true)
        {
            Bounds bounds = SpawnerBox.bounds;
            float x = Random.Range(bounds.min.x, bounds.max.x);
            float y = Random.Range(bounds.min.y, bounds.max.y);

            Transform platform = Instantiate(this.bodyPrefab);
            platform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
            platforms.Add(platform);

            yield return new WaitForSeconds(spawnInterval);         //Triggers a wait before the next enemy creation
        }
    }
}
