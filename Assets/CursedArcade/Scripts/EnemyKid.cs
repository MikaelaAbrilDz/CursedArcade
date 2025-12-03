using UnityEngine;

public class EnemyKid : EnemyAI
{
    public override void StartTurn()//Actions done at the start of the turn
    {
        if (CheckPathAndClearCheckers(CurrentChecker(), 3, typeof(EnemyKid)) != -1)
        {
            MoveTowardsPlayer();
        }
        else
        {
            MoveAwayFromPlayer();
        }
    }
}
