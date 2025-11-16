using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemyAI : CharacterOnGround
{
    public int nextMovement; //Next movement towards target when calling CheckForPath()
    void Start()
    {
        turnManager = FindAnyObjectByType<TurnManager>();
    }

    public override void StartTurn()
    {
        MoveTowardsPlayer();
        turnManager.PassTurn(this);
    }
    void MoveTowardsPlayer() //Uses turn to move towards the player
    {
        CurrentChecker().searched = 99;
        if (CheckForPath(CurrentChecker(), 10, typeof(PlayerController)) != -1)
        {
            Move(nextMovement);
        }
        ClearCheckers();
    }
    void ClearCheckers() //Clears every checker from having been searched
    {
        foreach (var aChecker in FindObjectsByType<Checker>(FindObjectsSortMode.None))
        {
            aChecker.searched = 0;
        }
    }
    int CheckForPath(Checker startChecker, int stepsLeft, Type target) //Finds the shortest path towards the target and returns -1 if there's no possible path
    {
        int[] allStepsLeft = new int[4];

        if (stepsLeft == 0) return -1;

        if (startChecker.positioned != null && startChecker.positioned.GetType() == target)
        {
            print("PLAYER FOUND");
            return stepsLeft;
        }

        for (int i = 0; i < 4; i++)
        {
            if (startChecker.sideCheckers[i] != null && startChecker.sideCheckers[i].searched < stepsLeft)
            {
                startChecker.sideCheckers[i].searched = stepsLeft;
                allStepsLeft[i] = CheckForPath(startChecker.sideCheckers[i], stepsLeft - 1, target);
            }
            else allStepsLeft[i] = -1;
        }

        int maxStepsLeft = allStepsLeft[0], firstStepDirection = 0;
        for (int i = 1  ; i < 4 ; i++)
        {
            if (maxStepsLeft < allStepsLeft[i] && allStepsLeft[i] != -1)
            {
                maxStepsLeft = allStepsLeft[i]; 
                firstStepDirection = i;
            }
        }
        nextMovement = firstStepDirection;
        return maxStepsLeft;
    }

}
