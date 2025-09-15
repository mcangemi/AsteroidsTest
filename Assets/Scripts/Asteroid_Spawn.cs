using System.Collections;
using UnityEngine;

public class Asteroid_Spawn : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public Vector2 spawnStart = new Vector2(9f, 2f);
    [SerializeField] private float maxAsteroids = 20f;
    public float currentAsteroids = 1f;

    void Start()
    {
        IEnumerator method = SpawnAsteroids();
        StartCoroutine(method);
    }

    IEnumerator SpawnAsteroids()
    {
        while (currentAsteroids < maxAsteroids)
        {
            Vector2 spawnPosition = new Vector2(-9, Random.Range(-spawnStart.y, spawnStart.y));
            Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
            currentAsteroids++;
            yield return new WaitForSeconds(maxAsteroids/(maxAsteroids-currentAsteroids));
        }
    }

}
