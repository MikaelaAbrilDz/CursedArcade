using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] int percentageOfObjects, percentageOfEnemies;

    void Awake()
    {
        SetSpawn();
    }

    private void SetSpawn()
    {
        FindAnyObjectByType<PlayerController>().SetPositionedChecker(true);

        Checker[] allChekers = FindObjectsByType<Checker>(FindObjectsSortMode.None);
        int ammountOfCheckersToSpawnObj = (int)(allChekers.Length * (percentageOfObjects/100f));
        int ammountOfCheckersToSpawnEnemy = (int)(allChekers.Length * (percentageOfEnemies/100f));

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
