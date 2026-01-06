using UnityEngine;

public class EnemyKid : EnemyAI
{
    public override void StartTurn()//Actions done at the start of the turn
    {
        if (CheckPathAndClearCheckers(CurrentChecker(), 1, typeof(PlayerController)) != -1)
        {
            StartCoroutine(AtackCo(stats._attack, 3, 1, 2, FindAnyObjectByType<PlayerController>(), 1, "Punch"));
        }
        else if (CheckPathAndClearCheckers(CurrentChecker(), 3, typeof(EnemyKid)) != -1)
        {
            MoveTowardsPlayer();
        }
        else
        {
            MoveAwayFromPlayer();
        }
    }
}
