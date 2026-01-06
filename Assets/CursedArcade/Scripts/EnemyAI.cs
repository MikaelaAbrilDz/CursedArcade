using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAI : CharacterOnGround
{
    protected int nextMovement; //Next movement towards target when calling CheckForPath()
    

    public override void StartTurn() //Actions done at the start of the turn
    {

    }
    protected void MoveTowardsPlayer() //Uses turn to move towards the player
    {
        if (CheckPathAndClearCheckers(CurrentChecker(), 10, typeof(PlayerController)) != -1)
        {
            if (!Move(nextMovement)) EndAction();
        }
        else EndAction();
    }
    protected void MoveAwayFromPlayer()
    {
        if (CheckPathAndClearCheckers(CurrentChecker(), 10, typeof(PlayerController)) != -1) //Checks possible movements away from player starting from directly away
        {
            if (!Move((nextMovement + 2) % 4))
            {
                if (!Move((nextMovement + 1) % 4))
                {
                    if (!Move((nextMovement + 3) % 4)) EndAction();
                }
            }
        }
        else EndAction();
    }
    protected int CheckPathAndClearCheckers(Checker startChecker, int stepsLeft, Type target)
    {
        CurrentChecker().searched = 99;
        int a = CheckForPath(startChecker, stepsLeft + 1, target); // Adds 1 to steps left to make values put in the original parameter more intuitive
        ClearCheckers();
        return a;
    }
    void ClearCheckers() //Clears every checker from having been searched
    {
        foreach (var aChecker in FindObjectsByType<Checker>(FindObjectsSortMode.None))
        {
            aChecker.searched = 0;
        }
    }
    private int CheckForPath(Checker startChecker, int stepsLeft, Type target) //Finds the shortest path towards the target and returns -1 if there's no possible path
    {
        int[] allStepsLeft = new int[4];

        if (stepsLeft == 0) return -1;

        if (startChecker.positioned != null && startChecker.positioned.GetType() == target && startChecker.positioned.gameObject != gameObject)
        {
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
