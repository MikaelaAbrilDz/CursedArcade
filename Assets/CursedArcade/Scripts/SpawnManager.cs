using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject healthKitPrefab; // Asigna el prefab en el inspector
    [SerializeField] private GameObject punchPrefab;     // Asigna el prefab en el inspector
    [SerializeField] int percentageOfObjects, percentageOfEnemies;

    void Awake()
    {
        SetSpawn();
    }

    private void SetSpawn()
    {
        Checker[] allChekers = FindObjectsByType<Checker>(FindObjectsSortMode.None);
        int ammountOfCheckersToSpawnObj = allChekers.Length / percentageOfObjects;
        int ammountOfCheckersToSpawnEnemy = allChekers.Length / percentageOfEnemies;

        for (int i = 0; i < ammountOfCheckersToSpawnObj; i++)
        {
            Checker checker = allChekers[UnityEngine.Random.Range(0, allChekers.Length)];

            if (checker.positioned == null) checker.SpawnObject();
        }

        for (int i = 0; i < ammountOfCheckersToSpawnEnemy; i++)
        {
            Checker checker = allChekers[UnityEngine.Random.Range(0, allChekers.Length)];

            if (checker.positioned == null) checker.SpawnEnemy();
        }
    }
}
