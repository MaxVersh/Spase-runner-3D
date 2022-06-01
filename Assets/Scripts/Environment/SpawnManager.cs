using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    private float spawnRange = 5.5f;
    private float spawnRate = 1.0f;
    private float yRange = 1.4f;
    private float offset = 1;
    public float spawnForward = 20;
    public float spawnForwardRange = 20;

    public int maxObjectsAmount;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private Vector3 GenerateSpawnPosition()
    {
        int dist = Random.Range(0, (int)spawnForwardRange);
        dist += (int)spawnForward;
        float spawnPositionX = Random.Range(-spawnRange, spawnRange);
        float spawnPositionZ = Random.Range(player.transform.position.z + spawnForward, player.transform.position.z + dist);
        float spawnPositionY = Random.Range(yRange, yRange + offset);
        Vector3 randomPosition = new Vector3(spawnPositionX, spawnPositionY,spawnPositionZ);
        return randomPosition;
    }
    IEnumerator SpawnTargets()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int amount = Random.Range(1, maxObjectsAmount + 1);
            for (int i = 0; i < amount; i++)
            {
                Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);                
            }
        }

    }
}
