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
        int ammountOfCheckersToSpawnObj = (int)(allChekers.Length * (percentageOfObjects/100f));
        int ammountOfCheckersToSpawnEnemy = (int)(allChekers.Length * (percentageOfEnemies/100f));
        print("PORCENTAJE: " + percentageOfEnemies/100f + " || CHECKERS: " + allChekers.Length + " || SPAWNERS: " + ammountOfCheckersToSpawnEnemy);
        print(ammountOfCheckersToSpawnObj);

        for (int i = 0; i < ammountOfCheckersToSpawnObj; i++)
        {
            Checker checker = allChekers[UnityEngine.Random.Range(0, allChekers.Length)];

            if (checker.positioned == null) checker.SpawnObject();
            else i--;
        }

        for (int i = 0; i < ammountOfCheckersToSpawnEnemy; i++)
        {
            Checker checker = allChekers[UnityEngine.Random.Range(0, allChekers.Length)];

            if (checker.positioned == null) checker.SpawnEnemy();
            else i--;
        }
    }
}
