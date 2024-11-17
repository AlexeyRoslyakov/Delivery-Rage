using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints; // Assign spawn points in the inspector
    public GameObject[] characterPrefabs; // Prefabs with different costumes
    public int characterCount = 5;

    void Start()
    {
        for (int i = 0; i < characterCount; i++)
        {
            SpawnCharacter();
        }
    }

    void SpawnCharacter()
    {
        // Pick a random spawn point and prefab
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject characterPrefab = characterPrefabs[Random.Range(0, characterPrefabs.Length)];
        
        // Spawn the character within a 5-unit radius
        Vector3 randomOffset = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        Instantiate(characterPrefab, spawnPoint.position + randomOffset, Quaternion.identity);
    }
}