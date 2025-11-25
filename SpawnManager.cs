using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject healthKitPrefab; // Asigna el prefab en el inspector
    [SerializeField] private GameObject punchPrefab;     // Asigna el prefab en el inspector

    void Start()
    {
        SetSpawn();
    }

    private void SetSpawn()
    {
        Checker[] allChekers = FindObjectsByType<Checker>(FindObjectsSortMode.None);
        int ammountOfCheckersToSpawn = allChekers.Length / 10;

        for (int i = 0; i < ammountOfCheckersToSpawn; i++)
        {
            Checker checker = allChekers[UnityEngine.Random.Range(0, allChekers.Length)];

            float chance = UnityEngine.Random.value; // 0.0 - 1.0

            if (chance <= 0.2f)
            {
                // 20% -> HealthKit
                SpawnEntityOnChecker(healthKitPrefab, checker);
            }
            else if (chance <= 0.3f)
            {
                // siguiente 10% (0.2 - 0.3) -> Punch
                SpawnEntityOnChecker(punchPrefab, checker);
            }
            else
            {
                // Resto -> spawn normal del checker (enemigos, etc.)
                checker.SpawnObject();
            }
        }
    }

    private void SpawnEntityOnChecker(GameObject prefab, Checker checker)
    {
        GameObject go = Instantiate(
            prefab,
            checker.transform.position,
            checker.transform.rotation
        );

        BasicEntity entity = go.GetComponent<BasicEntity>();
        if (entity != null)
        {
            // Esto hará que entity.CurrentChecker() sea este checker
            entity.SetPositionedChecker(true);
        }
    }

    void Update()
    {
    }
}
