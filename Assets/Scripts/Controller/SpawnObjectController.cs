using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectController : MonoBehaviour
{
    [SerializeField]private List<Transform> objectSpawnPoints; 
    [SerializeField]private List<GameObject> spawnObjects; 
    void Start()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        foreach (var spawnPoint in objectSpawnPoints)
        {
            int randomIndex = Random.Range(0, spawnObjects.Count);
            var spawnObject = Instantiate(spawnObjects[randomIndex], spawnPoint.position, Quaternion.identity);
            spawnObject.transform.parent = spawnPoint;
        }
    }
}
