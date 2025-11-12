using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyAI : CharacterOnGround
{
    bool isLookingForPath = false;
    List<List<int>> possiblePaths = new List<List<int>>();
    public List<int> finalPath;
    void Start()
    {
        turnManager = FindAnyObjectByType<TurnManager>();
    }

    // Update is called once per frame
    public override void StartTurn()
    {
            isLookingForPath = true;
            CurrentChecker().searched = 0;
            CheckForPath(CurrentChecker(), new List<int>(), 0);
            Invoke(nameof(DecidePath), 0.15f);
        
    }
    void DecidePath()
    {
        isLookingForPath = false;
        foreach (Checker checker in FindObjectsByType<Checker>(FindObjectsSortMode.None))
        {
            checker.searched = 99;
            //checker.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
        }
        if (possiblePaths.Count < 1)
        {
            turnManager.PassTurn(GetComponent<CharacterOnGround>());
            return;
        }
        finalPath = new List<int>(possiblePaths[0]);
        foreach (var path in possiblePaths)
        {
            if (path.Count < finalPath.Count) finalPath = new List<int>(path);
        }
        Move(finalPath[0]);
        possiblePaths.Clear();
    }
    void CheckForPath(Checker startChecker, List<int> currentPath, int counter)
    {
        if (!isLookingForPath || counter > 10) return;

        for (int i = 0; i < 4; i++)
        {
            if (startChecker.sideCheckers[i] != null && startChecker.sideCheckers[i].searched > counter)
            {
                startChecker.sideCheckers[i].searched = counter;
                startChecker.sideCheckers[i].GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                currentPath.Add(i);
                if (startChecker.sideCheckers[i].positioned != null && startChecker.sideCheckers[i].positioned.GetType() == typeof(PlayerController))
                {
                    possiblePaths.Add(new List<int>(currentPath));
                }
                else
                {
                    CheckForPath(startChecker.sideCheckers[i], new List<int>(currentPath), counter + 1);
                }
                currentPath.RemoveAt(currentPath.Count - 1);
            }
        }
    }

}
