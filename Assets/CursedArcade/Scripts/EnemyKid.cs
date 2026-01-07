using UnityEngine;

public class EnemyKid : EnemyAI
{
    public override void StartTurn()//Actions done at the start of the turn
    {
        if (CheckPathAndClearCheckers(CurrentChecker(), 1, typeof(PlayerController)) != -1)
        {
            Atack(stats._attack, 3, 1, 2, FindAnyObjectByType<PlayerController>(), 0.7f, "Punch");
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
