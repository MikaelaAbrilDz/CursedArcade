using UnityEngine;

public class EnemyEmployee : EnemyAI
{
    public override void StartTurn()//Actions done at the start of the turn
    {
        if (CheckPathAndClearCheckers(CurrentChecker(), 1, typeof(PlayerController)) != -1)
        {
            Atack(stats._attack, 3, 1, 1, FindAnyObjectByType<PlayerController>(), 0.7f, "Punch");
        }
        else
        {
            MoveTowardsPlayer();
        }
    }
}
