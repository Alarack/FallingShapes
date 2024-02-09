using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : Singleton<ObjectSpawner>
{

    [Header("Timing and Activation Variables")]
    public float minSpawnTime = 0.5f;
    public float maxSpawnTime = 2f;
    public bool activeSpawning;

    [Header("Spawnables and Spawn Points")]
    public List<CollectibleObject> spawnables = new List<CollectibleObject>();
    public List<Transform> spawnPoints = new List<Transform>();

    private float waitTime;

    private void Start() {
        StartCoroutine(SpawnObjects());
    }


    public static void StopSpawning() {
        Instance.StopAllCoroutines();

        CollectibleObject[] remaining = FindObjectsOfType<CollectibleObject>();
        for (int i = remaining.Length -1; i >= 0; i--) {
            remaining[i].ForceDie();
        }
    }

    public static void BeginSpawning() {
        Instance.StartCoroutine(Instance.SpawnObjects());
    }

    private IEnumerator SpawnObjects() {
       RandomizeWaitTime();

        while(activeSpawning == true) {
            CreateCollectibleObject();
            yield return new WaitForSeconds(waitTime);
            RandomizeWaitTime();
        }
    }

    private void RandomizeWaitTime() {
        waitTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void CreateCollectibleObject() {
        CollectibleObject target = spawnables[Random.Range(0, spawnables.Count)];
        Transform spawnPoint = spawnPoints[Random.Range(0,spawnPoints.Count)];

        Instantiate(target, spawnPoint.position, Quaternion.identity);
    }

}
