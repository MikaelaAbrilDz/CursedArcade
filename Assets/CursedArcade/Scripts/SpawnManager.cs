using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            allChekers[UnityEngine.Random.Range(0, allChekers.Length)].SpawnObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
