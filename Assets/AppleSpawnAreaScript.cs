using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawnAreaScript : MonoBehaviour
{

    public GameObject Apple;
    public float spawnRate = 3f; 
    private float timer = 0;

    private float minX = -19f;
    private float maxX = 19f;
    private float minZ = -19f;
    private float maxZ = 19f;
    private float fixedY = 0.7f; 

    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnApple();
            timer = 0;
        }
    }

    void spawnApple()
    {
        // Generate a random position within the defined bounds
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        Vector3 spawnPosition = new Vector3(randomX, fixedY, randomZ);

        // Spawn the apple
        Instantiate(Apple, spawnPosition, Quaternion.identity);
    }
}
